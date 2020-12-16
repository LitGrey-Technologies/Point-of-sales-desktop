using System;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Abstracts.Forms
{
    public partial class IsBusyForm : ViewBase
    {
        public Action Worker { get; set; }
        public IsBusyForm(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentNullException();
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Task.Factory.StartNew(Worker).ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
