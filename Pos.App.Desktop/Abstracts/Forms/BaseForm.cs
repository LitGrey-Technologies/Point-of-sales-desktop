using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts.Forms
{
    public class BaseForm : MetroFramework.Forms.MetroForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(523, 354);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy.Equals(value)) return;
                _isBusy = value;
                Cursor.Current = _isBusy ? Cursors.WaitCursor : Cursors.Default;
            }
        }
        //protected virtual void IsBusyDialog(Action action)
        //{
        //    using (var waitForm = new IsBusyForm(action))
        //    {
        //        waitForm.ShowDialog(this);
        //    }
        //}

    }
}
