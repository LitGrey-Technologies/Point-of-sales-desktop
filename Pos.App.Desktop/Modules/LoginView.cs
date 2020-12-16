using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules
{
    public partial class LoginView : BaseForm
    {
        private readonly IAuthenticationService _service;
        public LoginView()
        {
            InitializeComponent();
            _service = new AuthenticationService();
            _model = new Login();
        }

        private async void OnSignIn(object sender, System.EventArgs e)
        {
            SignInButton.Enabled = false;
            IsBusy = true;
            var modules = await _service.Authenticate(Model);
            if (modules != null)
            {
                var dashboard = new Dashboard();
                await dashboard.SetModules(modules);
                Hide();
                dashboard.ShowDialog(this);
            }
            IsBusy = false;
            SignInButton.Enabled = true;
        }

        private Login _model;
        public Login Model
        {
            get
            {
                if (_model == null)
                    return _model;
                _model.UserId = txtUserName.Text;
                _model.Password = txtPassword.Text;
                return _model;
            }
            set
            {
                _model = value;
                txtUserName.Text = _model.UserId;
                txtPassword.Text = _model.Password;
            }
        }

    }
}
