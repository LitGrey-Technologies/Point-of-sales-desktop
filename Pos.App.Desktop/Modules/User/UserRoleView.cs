using System.Windows.Forms;
using MetroFramework.Controls;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.User
{
    public partial class UserRoleView : ViewBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleView()
        {
            InitializeComponent();
            _userRoleService = new UserRoleService();
            SelectedItem = new UserRole();
            var genericCrud = new GenericCrud<UserRole>(this, _userRoleService.SaveAsync, _userRoleService.UpdateAsync, _userRoleService.DeleteAsync, _userRoleService.SearchAsync)
            {
                KeyControl = txtRoleId,
                SearchBox = txtSearchBox
            };
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var dataTable = await _userRoleService.GetAllAsync();
            SetDataSource(metroGrid1, dataTable);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtRoleId.Text = row.Cells["roleId"].Value.ToString(); 
            txtName.Text = row.Cells["description"].Value.ToString(); 
            cmbActive.Text = row.Cells["active"].Value.ToString();
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtRoleId.Text, "Role Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtName.Text, "Role Name "))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.SelectedValue?.ToString(), "Active/Deactivate account"))
            {
                return false;
            }
            return true;
        }

        private UserRole _selectedItem;
        public UserRole SelectedItem
        {
            get
            {
                _selectedItem.RoleId = txtRoleId.Text;
                _selectedItem.Description = txtName.Text;
                _selectedItem.Active = cmbActive.SelectedValue?.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }

    }
}