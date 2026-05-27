using System;
using System.Windows.Forms;
using StoreKeeper.WinForms.Forms;

namespace StoreKeeper.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Глобальний обробник необроблених виключень
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                MessageBox.Show($"Критична помилка: {e.ExceptionObject}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            };

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show($"Помилка: {e.Exception.Message}\n\n{e.Exception.StackTrace}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            try
            {
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при запуску: {ex.Message}\n\n{ex.StackTrace}", "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}