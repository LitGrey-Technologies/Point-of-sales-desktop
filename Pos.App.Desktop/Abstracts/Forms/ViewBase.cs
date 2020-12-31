using MetroFramework.Controls;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts.Forms
{
    public partial class ViewBase : BaseForm
    {
        public ViewBase()
        {
            InitializeComponent();
        }

        public void ViewLoadedAsync()
        {
            IsBusy = true;
            OnViewLoadedAsyncExecute();
            IsBusy = false;
        }

        protected virtual void OnViewLoadedAsyncExecute()
        {

        }

        public virtual void ClearInputs<T>(Form form) where T : class
        {
            IsBusy = true;
            form.Controls.ClearControls<T>();
            IsBusy = false;
        }

        public virtual void ViewClearInputsButtonCommand()
        {
            ClearInputs<MetroTextBox>(this);
            ClearInputs<MetroComboBox>(this);
        }
        public virtual void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {

        }
        public virtual bool ViewValidateInputs()
        {
            return true;
        }
        public virtual T GetSelectedItem<T>() where T : class
        {
            return default;
        }
        protected virtual bool ViewFieldValueRequiredValidation(string value, string displayName)
        {
            if (string.IsNullOrEmpty(value))
            {
                MessageDialog.Error($"Field {displayName} is required");
                return false;
            }
            return true;
        }
        protected virtual bool ViewFieldValueLengthValidation(string value, string displayName, int length)
        {
            if (value.Length < length)
            {
                MessageDialog.Error($"Field {displayName} should have {length} character length");
                return false;
            }
            return true;
        }
        protected virtual bool ViewFieldEmailValidation(string email, string displayName)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                if (mail.Address != email)
                {
                    MessageDialog.Error($"Field {displayName} is invalid");
                    return false;
                }
                return mail.Address == email;
            }
            catch
            {
                MessageDialog.Error($"Field {displayName} is invalid");
                return false;
            }
        }


        public void SetDataSource(MetroGrid gridView, DataTable dataTable)
        {
            gridView.DataSource = dataTable;
        }
        public void SetDataSource(MetroComboBox comboBox, ObservableCollection<NameValuePair> valuePairs)
        {
            comboBox.DataSource = valuePairs;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Value";
        }
    }
}
