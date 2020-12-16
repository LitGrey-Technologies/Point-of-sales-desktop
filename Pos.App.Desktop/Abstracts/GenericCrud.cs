using MetroFramework.Controls;
using Pos.App.Desktop.Abstracts.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts
{
    public class GenericCrud<T> where T : class
    {
        private readonly ViewBase _viewBase;
        private readonly Func<T, Task<bool>> _saveAction;
        private readonly Func<T, Task<bool>> _updateAction;
        private readonly Func<string, Task<bool>> _deleteAction;
        private readonly Func<string, Task<DataTable>> _searchAsync;
        public bool IsUpdate;

        public T SelectedItem
        {
            get
            {
                var item = _viewBase.GetSelectedItem<T>();
                return item;
            }

        }
        private MetroTextBox _keyControl;
        public MetroTextBox KeyControl
        {
            get => _keyControl;
            set
            {
                _keyControl = value;
                value.TextChanged += OnKeyControlTextChanged;
            }
        }

        public MetroTextBox SearchBox
        {
            set => value.TextChanged += SearchBoxTextChanged;
        }

        private async void SearchBoxTextChanged(object sender, EventArgs e)
        {
            _viewBase.IsBusy = true;
            var searchBox = sender as MetroTextBox;
            _gridView.DataSource = await _searchAsync.Invoke(searchBox?.Text);
            _viewBase.IsBusy = false;
        }

        public GenericCrud(ViewBase viewBase, Func<T, Task<bool>> saveAction, Func<T, Task<bool>> updateAction,
            Func<string, Task<bool>> deleteAction, Func<string, Task<DataTable>> searchAsync)
        {
            _viewBase = viewBase;
            _saveAction = saveAction;
            _updateAction = updateAction;
            _deleteAction = deleteAction;
            _searchAsync = searchAsync;
            _gridView = _viewBase.Controls.FindControl<MetroGrid>() as MetroGrid;
            CreateButtons();
            SubscribeControlsEvents();
            SetControlsDefaultValues();
        }

        private readonly MetroGrid _gridView;
        private MetroButton _loadButton;
        private MetroButton _saveButton;
        private MetroButton _addButton;
        private MetroButton _deleteButton;

        private void SubscribeControlsEvents()
        {
            _gridView.SelectionChanged += OnGridViewRowSelectionChange;
            _loadButton.Click += LoadButtonClick;
            _saveButton.Click += SaveButtonClick;
            _addButton.Click += AddButtonClick;
            _deleteButton.Click += DeleteButtonClick;
        }

        private void SetControlsDefaultValues()
        {
            _gridView.MultiSelect = false;
            _saveButton.Enabled = false;
            _addButton.Enabled = false;
            _deleteButton.Enabled = false;
        }
        private void OnGridViewRowSelectionChange(object sender, EventArgs e)
        {
            _viewBase.IsBusy = true;
            if (_gridView.Rows.Count > 0 && _gridView.SelectedRows.Count > 0)
            {
                var row = _gridView.SelectedRows;
                _viewBase.ViewDataGridSelectionChangedCommand(row[0]);
            }
            IsUpdate = true;
            if (KeyControl != null)
            {
                KeyControl.Enabled = false;
            }
            _deleteButton.Enabled = true;
            _viewBase.IsBusy = false;
        }
        private async void DeleteButtonClick(object sender, EventArgs e)
        {
            _viewBase.IsBusy = true;
            if (KeyControl != null)
            {
                var response = await _deleteAction.Invoke(KeyControl.Text);
                if (response)
                {
                    MessageDialog.Information("Deleted SuccessFully.");
                    ClearData();
                    _viewBase.ViewLoadedAsync();
                }
                else
                {
                    MessageDialog.Error("Something went wrong.");
                }
            }
            else
            {
                MessageDialog.Error("Key is not text box.");
            }
            _viewBase.IsBusy = false;
        }
        private void OnKeyControlTextChanged(object sender, EventArgs e)
        {
            _saveButton.Enabled = KeyControl.Text.Length > 0;
        }
        private void AddButtonClick(object sender, EventArgs e)
        {
            ClearData();
            _deleteButton.Enabled = false;
            IsUpdate = false;
        }

        private void ClearData()
        {
            _viewBase.ViewClearInputsButtonCommand();
            KeyControl.Enabled = true;
        }
        private async void SaveButtonClick(object sender, EventArgs e)
        {
            _viewBase.IsBusy = true;
            if (_viewBase.ViewValidateInputs())
            {
                bool response;
                if (IsUpdate)
                {
                    response = await _updateAction.Invoke(SelectedItem);
                }
                else
                {
                    response = await _saveAction.Invoke(SelectedItem);
                }
                if (response)
                {
                    MessageDialog.Information("Saved SuccessFully.");
                    _viewBase.ViewClearInputsButtonCommand();
                    _viewBase.ViewLoadedAsync();
                }
                else
                {
                    MessageDialog.Error("Something went wrong.");
                }
            }
            _viewBase.IsBusy = false;
        }

        private void LoadButtonClick(object sender, EventArgs e)
        {
            _viewBase.IsBusy = true;
            _viewBase.ViewLoadedAsync();
            _viewBase.IsBusy = false;
            _loadButton.Enabled = false;
            _addButton.Enabled = true;
            _deleteButton.Enabled = true;
        }

        private void CreateButtons()
        {
            int GetLocationAlongX()
            {
                return _viewBase.ClientSize.Width - 347;
            }
            var containerPanel = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(332, 34),
                Location = new Point(GetLocationAlongX(), 23)
            };
            _loadButton = new MetroButton
            {
                Text = @"Load",
                Anchor = AnchorStyles.Right,
                Location = new Point(250, 5)
            };
            _saveButton = new MetroButton
            {
                Text = @"Save",
                Anchor = AnchorStyles.Right,
                Location = new Point(169, 5)
            };
            _deleteButton = new MetroButton
            {
                Text = @"Delete",
                Anchor = AnchorStyles.Right,
                Location = new Point(88, 5)
            };
            _addButton = new MetroButton
            {
                Text = @"Add New",
                Anchor = AnchorStyles.Right,
                Location = new Point(7, 5)
            };
            if (_saveAction != null)
            {
                containerPanel.Controls.Add(_saveButton);
            }
            if (_deleteAction != null)
            {
                containerPanel.Controls.Add(_deleteButton);
            }
            if (_gridView != null)
            {
                containerPanel.Controls.Add(_addButton);
            }
            containerPanel.Controls.Add(_loadButton);
            _viewBase.Controls.Add(containerPanel);
        }
    }
}
