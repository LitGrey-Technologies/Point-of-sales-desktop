using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Customer
{
    public partial class CustomerHistory : ViewBase
    {
        private readonly ICustomerService _customer;
        public CustomerHistory()
        {
            InitializeComponent();
            _customer = new CustomerService();
            OnViewLoadedAsyncExecute();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var customers = await _customer.GetLookUps();
            SetDataSource(metroComboBox1, customers);
            IsBusy = false;
        }

        private async void metroButton1_Click(object sender, System.EventArgs e)
        {
            IsBusy = true;
            var itemsSource = await _customer.CustomerHistory(metroComboBox1.SelectedValue as string);
            SetDataSource(metroGrid1, itemsSource);
            IsBusy = false;
        }

        private void metroGrid1_Click(object sender, System.EventArgs e)
        {
            IsBusy = true;
            var invoiceId = metroGrid1.SelectedRows[0]?.Cells[0]?.Value?.ToString();
            var details = new CustomerHistoryDetails(invoiceId);
            IsBusy = false;
            details.ShowDialog();
        }
    }
}
