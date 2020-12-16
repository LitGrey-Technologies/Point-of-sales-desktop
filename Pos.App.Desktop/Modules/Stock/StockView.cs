using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;

namespace Pos.App.Desktop.Modules.Stock
{
    public partial class StockView : ViewBase
    {
        private readonly IStockService _stockService;
        public StockView()
        {
            InitializeComponent();
            _stockService = new StockService();
            ViewLoadedAsync();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            IsBusy = true;
            var data = await _stockService.GetStock();
            SetDataSource(metroGrid1, data);
            IsBusy = false;
        }
    }
}
