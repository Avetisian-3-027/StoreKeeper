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
            Application.Run(new LoginForm());
        }
    }
}