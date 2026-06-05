using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.WinForms.Reports;

namespace StoreKeeper.WinForms.Forms
{
    public partial class AuditLogForm : Form
    {
        private WorkDbContext _context;

        public AuditLogForm(WorkDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadLogs();
        }

        private void LoadLogs()
        {
            var logs = _context.AuditLogs
                .Include(l => l.Invoice)
                    .ThenInclude(i => i.InvoiceItems)
                    .ThenInclude(ii => ii.Product)
                .OrderByDescending(l => l.Timestamp)
                .ToList();

            dataGridViewLogs.AutoGenerateColumns = false;
            dataGridViewLogs.Columns.Clear();

            // Колонка "Дата"
            dataGridViewLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Timestamp",
                HeaderText = "Дата",
                DataPropertyName = "Timestamp",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm:ss" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            // Колонка "Користувач"
            dataGridViewLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Користувач",
                DataPropertyName = "Username",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            // Колонка "Деталі" (без колонки "Дія")
            dataGridViewLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Details",
                HeaderText = "Деталі",
                DataPropertyName = "Details",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            // Кнопка друку накладної
            if (!dataGridViewLogs.Columns.Contains("PrintColumn"))
            {
                var printColumn = new DataGridViewButtonColumn
                {
                    Name = "PrintColumn",
                    HeaderText = "Друк",
                    Text = "Друк накладної",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridViewLogs.Columns.Add(printColumn);
            }

            dataGridViewLogs.DataSource = logs;
        }

        private void dataGridViewLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridViewLogs.Columns[e.ColumnIndex].Name == "PrintColumn")
            {
                var log = dataGridViewLogs.Rows[e.RowIndex].DataBoundItem as AuditLog;
                if (log?.InvoiceId != null && log.Invoice != null)
                {
                    var invoice = log.Invoice;
                    var items = invoice.InvoiceItems.ToList();
                    if (items.Any())
                    {
                        var saveDialog = new SaveFileDialog
                        {
                            Filter = "DOCX files (*.docx)|*.docx",
                            FileName = $"Invoice_{invoice.Number}_{invoice.Date:yyyyMMdd}.docx"
                        };
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            DocxHelper.GenerateInvoiceDocx(invoice, items, saveDialog.FileName);
                            try
                            {
                                var psi = new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                                {
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(psi);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Файл збережено, але не вдалося відкрити: {ex.Message}", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Накладна не містить позицій.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ця подія не пов'язана з накладною або накладну не знайдено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}