using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Customer
{
    public partial class CustomerHistoryDetails : ViewBase
    {
        private readonly ICustomerService _customer;
        private readonly string _invoiceId;

        public CustomerHistoryDetails(string invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            _customer = new CustomerService();
            OnViewLoadedAsyncExecute();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var itemsSource = await _customer.CustomerHistoryDetails(_invoiceId);
            SetDataSource(metroGrid1, itemsSource);
            IsBusy = false;
        }
    }
}
