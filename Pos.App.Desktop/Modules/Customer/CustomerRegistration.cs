using System.Windows.Forms;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Customer
{
    public partial class CustomerRegistration : ViewBase
    {
        private readonly ICustomerService _customerService;
        public CustomerRegistration()
        {
            InitializeComponent();
            _customerService = new CustomerService(); SelectedItem=new Models.Customer();
             var generic = new GenericCrud<Models.Customer>(this, _customerService.SaveAsync, _customerService.UpdateAsync,
                _customerService.DeleteAsync, _customerService.SearchAsync)
            {
                SearchBox = txtSearchBox,
                KeyControl = txtCustomerId
            };
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var data = await _customerService.GetAllAsync();
            SetDataSource(metroGrid1, data);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtCustomerId.Text = row.Cells["customerId"].Value.ToString();
            txtName.Text = row.Cells["name"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();
            txtContactNumber.Text = row.Cells["contact_number"].Value.ToString();
            txtAddress.Text = row.Cells["addresss"].Value.ToString();
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtCustomerId.Text, "Customer Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtName.Text, "Customer Name"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtContactNumber.Text, "Customer Contact Number"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.Text, "Activate/Deactivate Customer "))
            {
                return false;
            }
            if (!ViewFieldEmailValidation(txtEmail.Text, "Customer Email Address"))
            {
                return false;
            }
            return true;
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        private Models.Customer _selectedItem;
        public Models.Customer SelectedItem
        {
            get
            {
                _selectedItem.CustomerId = txtCustomerId.Text;
                _selectedItem.Name = txtName.Text;
                _selectedItem.Email = txtEmail.Text;
                _selectedItem.Contact = txtContactNumber.Text;
                _selectedItem.Address = txtAddress.Text;
                _selectedItem.Active = cmbActive.SelectedValue.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }

    }
}
