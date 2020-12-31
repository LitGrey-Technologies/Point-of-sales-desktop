using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;
using System;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules.User
{
    public partial class UserPermissionsView : ViewBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly UserPermissionsViewManger _permissionsManger;

        public UserPermissionsView()
        {
            InitializeComponent();
            _userRegistrationService = new UserRegistrationService();
            _permissionsManger = new UserPermissionsViewManger();
            OnViewLoadedAsyncExecute();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var users = await _userRegistrationService.GetLookUpsAsync();
            SetDataSource(metroComboBox1, users);
            treeView1 = await _permissionsManger.OnLoadMenuItems(treeView1);
            metroComboBox1.SelectedIndex = -1;
            IsBusy = false;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            IsBusy = true;
            _permissionsManger.OnTreeViewCheckBoxChanged(e);
            IsBusy = false;
        }

        private async void metroComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var id = metroComboBox1.SelectedValue as string;
            if (string.IsNullOrEmpty(id)) return;
            IsBusy = true;
            treeView1 = await _permissionsManger.OnSelectionChanged(treeView1, id);
            treeView1.AfterCheck += treeView1_AfterCheck;
            IsBusy = false;
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            IsBusy = true;
            metroButton1.Enabled = false;
            var id = metroComboBox1.SelectedValue as string;
            var results = await _permissionsManger.OnSaveAsync(id);
            if (results)
            {
                MessageDialog.Information("Saved SuccessFully");
            }
            else
            {
                MessageDialog.Error("Something went wrong.");
            }
            metroButton1.Enabled = true;
            IsBusy = false;
        }
    }
}

