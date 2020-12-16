using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts
{
    public class MessageDialog
    {
        public static void Error(string message)
        {
            MessageBox.Show(message, @"System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void Information(string message)
        {
            MessageBox.Show(message, @"System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Question(string message)
        {
            MessageBox.Show(message, @"System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}