using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules.User
{
    public partial class UserRegistrationView : ViewBase
    {
        private readonly IUserRegistrationService _service;
        private readonly IUserRoleService _roleService;
        private readonly GenericCrud<Models.User> _genericCrud;
        public UserRegistrationView()
        {
            InitializeComponent();
            _service = new UserRegistrationService();
            _roleService = new UserRoleService();
            SelectedItem = new Models.User();

            _genericCrud = new GenericCrud<Models.User>(this, _service.SaveAsync, _service.UpdateAsync,
                _service.DeleteAsync, _service.SearchAsync)
            {
                KeyControl = txtUserId,
                SearchBox = metroTextBox1
            };
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var dataTable = await _service.GetAllAsync();
            SetDataSource(metroGrid1, dataTable);
            var roles = await _roleService.GetLookUps();
            SetDataSource(cmbRole, roles);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
            IsBusy = false;
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtUserId.Text, "User Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtName.Text, "User Name"))
            {
                return false;
            }

            if (!_genericCrud.IsUpdate)
            {
                if (!ViewFieldValueRequiredValidation(txtPassword.Text, "Password") || !ViewFieldValueLengthValidation(txtPassword.Text, "Password", 6))
                {
                    return false;
                }
            }

            if (!ViewFieldEmailValidation(txtEmail.Text, "Email") || !ViewFieldValueRequiredValidation(txtEmail.Text, "Email"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbRole.SelectedValue?.ToString(), "Role"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.SelectedValue?.ToString(), "Active"))
            {
                return false;
            }

            return true;
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtUserId.Text = row.Cells["userId"].Value.ToString();
            txtName.Text = row.Cells["name"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();
            cmbRole.Text = row.Cells["description"].Value.ToString();
            cmbActive.Text = row.Cells["active"].Value.ToString();
        }

        private Models.User _selectedItem;
        public Models.User SelectedItem
        {
            get
            {
                _selectedItem.UserId = txtUserId.Text;
                _selectedItem.Name = txtName.Text;
                _selectedItem.Password = txtPassword.Text;
                _selectedItem.Email = txtEmail.Text;
                _selectedItem.RoleId = cmbRole.SelectedValue?.ToString();
                _selectedItem.Active = cmbActive.SelectedValue?.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }
    }
}
