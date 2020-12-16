using System;
using System.Windows.Forms;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Vendor
{
    public partial class VendorRegistrationView : ViewBase
    {
        private readonly IVendorService _vendorService;

        public VendorRegistrationView()
        {
            InitializeComponent();
            _vendorService = new VendorService();
            SelectedItem=new Models.Vendor();
            var generic = new GenericCrud<Models.Vendor>(this, _vendorService.SaveAsync, _vendorService.UpdateAsync,
                _vendorService.DeleteAsync, _vendorService.SearchAsync)
            {
                KeyControl =txtVendorId,
                SearchBox = txtSearchBox
            };
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var dataTable = await _vendorService.GetAllAsync();
            SetDataSource(metroGrid1, dataTable);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtVendorId.Text = row.Cells["vendorId"].Value.ToString();
            txtName.Text = row.Cells["name"].Value.ToString();
            txtContactNumber.Text = row.Cells["contactNumber"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();
            cmbActive.Text = row.Cells["active"].Value.ToString();
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtVendorId.Text,"Vendor Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtName.Text, "Vendor Name"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtContactNumber.Text, "Vendor Contact Number"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.Text, "Activate/Deactivate Vendor "))
            {
                return false;
            }
            if (!ViewFieldEmailValidation(txtEmail.Text, "Email Address"))
            {
                return false;
            }
            return true;
        }

        private Models.Vendor _selectedItem;
        public Models.Vendor SelectedItem
        {
            get
            {
                _selectedItem.Name = txtName.Text;
                _selectedItem.Email = txtEmail.Text;
                _selectedItem.Contact = txtContactNumber.Text;
                _selectedItem.VendorId = txtVendorId.Text;
                _selectedItem.RegDate = DateTime.Now.ToShortDateString();
                _selectedItem.Active = cmbActive.SelectedValue.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }

    }
}
