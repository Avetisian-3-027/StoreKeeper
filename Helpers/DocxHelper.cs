using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using StoreKeeper.Data.Models.Work;

namespace StoreKeeper.WinForms.Reports
{
    public static class DocxHelper
    {
        private static void AddTableBorders(Table table)
        {
            var borders = new TableBorders(
                new TopBorder { Val = BorderValues.Single, Size = 12 },
                new BottomBorder { Val = BorderValues.Single, Size = 12 },
                new LeftBorder { Val = BorderValues.Single, Size = 12 },
                new RightBorder { Val = BorderValues.Single, Size = 12 },
                new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
                new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 }
            );
            table.TableProperties = new TableProperties(new TableWidth { Type = TableWidthUnitValues.Dxa, Width = "8500" }, borders);
        }

        public static void GenerateInvoiceDocx(Invoice invoice, List<InvoiceItem> items, string filePath, string companyName = "ТОВ \"Склад\"")
        {
            using (var wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                var mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                var docBody = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text(companyName)) { RunProperties = new RunProperties(new Bold(), new FontSize { Val = "32" }) }));
                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text(invoice.Type == 1 ? "ПРИХІДНА НАКЛАДНА" : "ВИДАТКОВА НАКЛАДНА")) { RunProperties = new RunProperties(new Bold(), new FontSize { Val = "28" }) }));
                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text($"№ {invoice.Number} від {invoice.Date:dd.MM.yyyy}"))));
                if (invoice.Type == 1 && !string.IsNullOrEmpty(invoice.Supplier))
                    docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text($"Постачальник: {invoice.Supplier}"))));
                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text($"Коментар: {invoice.Comment ?? "—"}"))));

                var table = new Table();
                AddTableBorders(table);

                var headerRow = new TableRow();
                headerRow.AppendChild(CreateTableCell("Товар", 3000));
                headerRow.AppendChild(CreateTableCell("Кількість (кг)", 1500));
                headerRow.AppendChild(CreateTableCell("Ціна за кг", 1500));
                headerRow.AppendChild(CreateTableCell("Сума", 1500));
                table.AppendChild(headerRow);

                foreach (var item in items)
                {
                    var row = new TableRow();
                    row.AppendChild(CreateTableCell(item.Product?.Name ?? "Невідомо", 3000));
                    row.AppendChild(CreateTableCell($"{item.Quantity:N3}", 1500, true));
                    row.AppendChild(CreateTableCell($"{item.PricePerKg:N2}", 1500, true));
                    row.AppendChild(CreateTableCell($"{(item.Quantity * item.PricePerKg):N2}", 1500, true));
                    table.AppendChild(row);
                }
                var totalRow = new TableRow();
                totalRow.AppendChild(CreateTableCell("РАЗОМ:", 3000));
                totalRow.AppendChild(CreateTableCell("", 1500));
                totalRow.AppendChild(CreateTableCell("", 1500));
                totalRow.AppendChild(CreateTableCell($"{items.Sum(i => i.Quantity * i.PricePerKg):N2}", 1500, true));
                table.AppendChild(totalRow);
                docBody.AppendChild(table);

                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text(" "))));
                var signaturesPara = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                signaturesPara.AppendChild(new Run(new Text("Відповідальна особа: ____________________ (підпис)")));
                signaturesPara.AppendChild(new Break());
                signaturesPara.AppendChild(new Run(new Text("Бухгалтер: ____________________ (підпис)")));
                signaturesPara.AppendChild(new Break());
                signaturesPara.AppendChild(new Run(new Text("М.П.")));
                docBody.AppendChild(signaturesPara);
                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text($"\nЗгенеровано {DateTime.Now:dd.MM.yyyy HH:mm:ss}"))));
            }
        }

        public static void GenerateStockReportDocx(List<Product> products, string filePath, string title = "Звіт по залишках товарів")
        {
            using (var wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                var mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                var docBody = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text(title)) { RunProperties = new RunProperties(new Bold(), new FontSize { Val = "32" }) }));

                var table = new Table();
                AddTableBorders(table);

                var headerRow = new TableRow();
                headerRow.AppendChild(CreateTableCell("Назва товару", 3500));
                headerRow.AppendChild(CreateTableCell("Кількість (кг)", 1500));
                headerRow.AppendChild(CreateTableCell("Ціна за кг", 1500));
                headerRow.AppendChild(CreateTableCell("Вартість", 1500));
                table.AppendChild(headerRow);

                decimal totalValue = 0;
                foreach (var p in products.OrderBy(p => p.Name))
                {
                    var row = new TableRow();
                    row.AppendChild(CreateTableCell(p.Name, 3500));
                    row.AppendChild(CreateTableCell($"{p.Quantity:N3}", 1500, true));
                    row.AppendChild(CreateTableCell($"{p.PricePerKg:N2}", 1500, true));
                    decimal value = p.Quantity * p.PricePerKg;
                    row.AppendChild(CreateTableCell($"{value:N2}", 1500, true));
                    table.AppendChild(row);
                    totalValue += value;
                }
                var totalRow = new TableRow();
                totalRow.AppendChild(CreateTableCell("РАЗОМ:", 3500));
                totalRow.AppendChild(CreateTableCell("", 1500));
                totalRow.AppendChild(CreateTableCell("", 1500));
                totalRow.AppendChild(CreateTableCell($"{totalValue:N2}", 1500, true));
                table.AppendChild(totalRow);
                docBody.AppendChild(table);

                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text(" "))));
                var signaturesPara = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                signaturesPara.AppendChild(new Run(new Text("Відповідальна особа: ____________________ (підпис)")));
                signaturesPara.AppendChild(new Break());
                signaturesPara.AppendChild(new Run(new Text("Бухгалтер: ____________________ (підпис)")));
                signaturesPara.AppendChild(new Break());
                signaturesPara.AppendChild(new Run(new Text("М.П.")));
                docBody.AppendChild(signaturesPara);
                docBody.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new Run(new Text($"\nЗгенеровано {DateTime.Now:dd.MM.yyyy HH:mm:ss}"))));
            }
        }

        private static TableCell CreateTableCell(string text, int width, bool isRightAlign = false)
        {
            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            if (isRightAlign)
                paragraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Right });
            var run = new Run(new Text(text));
            paragraph.AppendChild(run);
            var cell = new TableCell(paragraph);
            cell.TableCellProperties = new TableCellProperties(new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = width.ToString() });
            return cell;
        }
    }
}