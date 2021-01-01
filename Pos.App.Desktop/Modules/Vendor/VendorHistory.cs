using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Vendor
{
    public partial class VendorHistory : ViewBase
    {
        private readonly IVendorService _vendorService;
        public VendorHistory()
        {
            InitializeComponent();
            _vendorService = new VendorService();
            OnViewLoadedAsyncExecute();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var venders = await _vendorService.GetLookUps();
            SetDataSource(metroComboBox1, venders);
            IsBusy = false;
        }

        private async void metroButton1_Click(object sender, System.EventArgs e)
        {
            IsBusy = true;
            var itemsSource = await _vendorService.VendorHistory(metroComboBox1.SelectedValue as string);
            SetDataSource(metroGrid1, itemsSource);
            IsBusy = false;
        }
        private void metroGrid1_Click(object sender, System.EventArgs e)
        {
            IsBusy = true;
            var invoiceId = metroGrid1.SelectedRows[0]?.Cells[0]?.Value?.ToString();
            var details = new VendorHistoryDetails(invoiceId);
            IsBusy = false;
            details.ShowDialog();
        }
    }
}
