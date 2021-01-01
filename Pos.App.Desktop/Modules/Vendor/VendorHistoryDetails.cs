using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Vendor
{
    public partial class VendorHistoryDetails : ViewBase
    {
        private readonly string _invoiceId;
        private readonly IVendorService _vendorService;
        public VendorHistoryDetails(string invoiceId)
        {
            _invoiceId = invoiceId;
            _vendorService=new VendorService();
            InitializeComponent();
            OnViewLoadedAsyncExecute();
        }
        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var itemsSource = await _vendorService.VendorHistoryDetails(_invoiceId);
            SetDataSource(metroGrid1, itemsSource);
            IsBusy = false;
        }
    }
}
