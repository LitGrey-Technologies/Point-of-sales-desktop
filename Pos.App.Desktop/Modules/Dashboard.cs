using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Modules.Customer;
using Pos.App.Desktop.Modules.Product;
using Pos.App.Desktop.Modules.Stock;
using Pos.App.Desktop.Modules.User;
using Pos.App.Desktop.Modules.Vendor;
using Pos.App.Desktop.Services;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules
{
    public partial class Dashboard : BaseForm
    {
        private readonly IAuthenticationService _service;
        public Dashboard()
        {
            InitializeComponent();
            _service = new AuthenticationService();
        }

        public async Task SetModules(DataTable dataTable)
        {
            await Task.Run(() =>
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var menuId = row.ItemArray[1].ToString();
                    var title = row.ItemArray[10].ToString();
                    var routerLink = row.ItemArray[11].ToString();
                    Modules.AddItem(title, routerLink, menuId, OnModuleItemClick);
                }
            });
        }

        private async void OnModuleItemClick(object sender, EventArgs e)
        {
            IsBusy = true;
            var selectedItem = sender as ToolStripMenuItem;
            if (selectedItem?.DropDownItems.Count == 0)
            {
                var userId = await Session.GetItem("CURRENT_USER_ID");
                var child = await _service.GetChild(selectedItem.Name, userId.Value);
                selectedItem.DropDownItems.AddItem(child, OnChildItemClick);
            }
            IsBusy = false;
        }

        private void OnChildItemClick(object sender, EventArgs e)
        {
            IsBusy = true;
            var selectedItem = sender as ToolStripMenuItem;
            var name = selectedItem?.Tag as string;
            switch (name)
            {
                case "us_reg":
                    {
                        SelectedView(new UserRegistrationView());
                        break;
                    }
                case "us_rol":
                    {
                        SelectedView(new UserRoleView());
                        break;
                    }
                case "us_pr":
                    {
                        SelectedView(new UserPermissionsView());
                        break;
                    }
                case "prd_reg":
                    {
                        SelectedView(new ProductRegistrationView());
                        break;
                    }
                case "prd_cat":
                    {
                        SelectedView(new ProductCategoryView());
                        break;
                    }
                case "vn_reg":
                    {
                        SelectedView(new VendorRegistrationView());
                        break;
                    }
                case "st_dir":
                    {
                        SelectedView(new StockView());
                        break;
                    }
                case "cus_reg":
                    {
                        SelectedView(new CustomerRegistration());
                        break;
                    }
                case "cus_dir":
                    {
                        SelectedView(new StockView());
                        break;
                    }
                case "prd_purc":
                    {
                        SelectedView(new ProductPurchase());
                        break;
                    }
                case "prd_sal":
                    {
                        SelectedView(new ProductSale());
                        break;
                    }
            }
            IsBusy = false;
        }

        private void SelectedView<T>(T type)
        {
            var form = type as Form;
            form?.ShowDialog(this);
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(e);
        }
    }
}
