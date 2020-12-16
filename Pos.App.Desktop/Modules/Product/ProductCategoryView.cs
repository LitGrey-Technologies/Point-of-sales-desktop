using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules.Product
{
    public partial class ProductCategoryView : ViewBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryView()
        {
            InitializeComponent();
            SelectedItem = new ProductCategory();
            _productCategoryService = new ProductCategoryService();
            var genericCrud = new GenericCrud<ProductCategory>(this, _productCategoryService.SaveAsync, _productCategoryService.UpdateAsync, _productCategoryService.DeleteAsync, _productCategoryService.SearchAsync)
            {
                SearchBox = txtSearchBox,
                KeyControl = txtCategoryId
            };
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var data = await _productCategoryService.GetAllAsync();
            SetDataSource(metroGrid1, data);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtCategoryId.Text, "Category Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtDescription.Text, "Category Description"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.Text, "Active/Deactivate Category"))
            {
                return false;
            }
            return true;
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtCategoryId.Text = row.Cells["categoryId"].Value.ToString();
            txtDescription.Text = row.Cells["description"].Value.ToString();
            cmbActive.Text = row.Cells["active"].Value.ToString();
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        private ProductCategory _selectedItem;
        public ProductCategory SelectedItem
        {
            get
            {
                _selectedItem.CategoryId = txtCategoryId.Text;
                _selectedItem.Description = txtDescription.Text;
                _selectedItem.Active = cmbActive.SelectedValue.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }

    }
}
