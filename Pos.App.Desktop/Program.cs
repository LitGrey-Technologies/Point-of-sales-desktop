using Pos.App.Desktop.Modules;
using System;
using System.Windows.Forms;

namespace Pos.App.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView());/*as());*/
        }
    }
}
