using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts
{
    public static class Extensions
    {
        public static void CentralizedPanelToParent(this Form form, Panel panel)
        {
            panel.Location = new Point(
                form.ClientSize.Width / 2 - panel.Size.Width / 2,
                form.ClientSize.Height / 2 - panel.Size.Height / 2);
            panel.Anchor = AnchorStyles.None;
        }

        public static string FetchValue(this DataGridView gridView, string fieldName)
        {
            return gridView.CurrentRow?.Cells[fieldName].Value?.ToString();
        }

        public static void AddItem(this MenuStrip menu, string title, string routerLink, string id, EventHandler onClick)
        {
            var newItem = menu.Items.Add(title, null, onClick);
            newItem.Tag = routerLink;
            newItem.Name = id;
        }
        public static void SetCheckBoxStatusForAllNodes(this TreeView treeView, bool status)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                node.Checked = status;
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = status;
                }
            }
        }
        public static void AddBooleanSource(this ComboBox cmb)
        {
            //cmb.DataSource = ViewBase.BooleanCollection;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Value";
            cmb.SelectedIndex = -1;
        }
        public static void AddDataSource(this ComboBox cmb, object dataSource, string displayMember, string valueMember)
        {
            cmb.DataSource = dataSource;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.SelectedIndex = -1;
        }

        public static void AddItem(this ToolStripItemCollection menu, DataTable subModules, EventHandler onClick)
        {
            menu.Clear();
            foreach (DataRow subModule in subModules.Rows)
            {
                var title = subModule.ItemArray[10].ToString();
                var routerLink = subModule.ItemArray[11].ToString();
                var newItem = menu.Add(title, null, onClick);
                newItem.Tag = routerLink;
                //newItem.Name= menuId;
            }
        }
        public static void BindWith<T>(this Control control, T model, string propertyPath, string bindWithControlPropertyName = "Text", DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
        {
            control.DataBindings.Clear();
            control.DataBindings.Add(new Binding(bindWithControlPropertyName, model, propertyPath, true, updateMode));
        }
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
