using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules.User
{
    public class UserPermissionsViewManger
    {
        private readonly IUserAccessService _userAccessService;
        private readonly List<NameValuePair<bool>> _ids;
        public UserPermissionsViewManger()
        {
            _ids = new List<NameValuePair<bool>>();
            _userAccessService = new UserAccessService();
        }

        public async Task<TreeView> OnSelectionChanged(TreeView treeView, string id)
        {
            var dataTable = await _userAccessService.GetUserLevelMenuAsync(id);
            treeView.SetCheckBoxStatusForAllNodes(false);
            foreach (DataRow row in dataTable.Rows)
            {
                var title = row.ItemArray[1].ToString();
                bool isFound = false;
                foreach (TreeNode node in treeView.Nodes)
                {
                    if (node.Text == title)
                    {
                        node.Checked = true;
                        AddId(node.Name, true);
                        isFound = true;
                        break;
                    }

                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.Text == title)
                            {
                                childNode.Checked = true;
                                AddId(childNode.Name, true);
                                isFound = true;
                                break;
                            }
                        }

                        if (isFound)
                        {
                            break;
                        }
                    }

                }

                if (isFound)
                {
                    isFound = false;
                    continue;
                }
            }

            return treeView;
        }

        public void OnTreeViewCheckBoxChanged(TreeViewEventArgs e)
        {
            var parentNode = e.Node;
            var parentNodeStatus = parentNode.Checked;
            if (parentNodeStatus)
            {
                AddId(parentNode.Name, false);
            }

            if (parentNode.Nodes.Count > 0)
            {
                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.Checked)
                    {
                        AddId(parentNode.Name, false);
                    }

                    if (!childNode.Checked)
                    {
                        FindAndRemoveFromIds(parentNode.Name);
                    }
                }
            }
        }

        private void AddId(string id, bool isEdit)
        {
            var isFound = _ids.Exists(a => a.Name == id);
            if (!isFound)
            {
                _ids.Add(new NameValuePair<bool>(id, isEdit));
            }
        }

        private void FindAndRemoveFromIds(string parentNodeName)
        {
            var isFound = _ids.Find(a => a.Name == parentNodeName);
            if (isFound != null)
            {
                _ids.Remove(isFound);
            }
        }

        public async Task<TreeView> OnLoadMenuItems(TreeView treeView)
        {
            var data = await _userAccessService.GetMenuAsync();
            treeView.Nodes.Clear();
            foreach (DataRow row in data.Rows)
            {
                var parentMenuId = Convert.ToInt32(row.ItemArray[0]);
                var parentTitle = row.ItemArray[1].ToString();
                var moduleId = Convert.ToInt32(row.ItemArray[2]);
                var node = new TreeNode();
                if (moduleId == 0)
                {
                    node = treeView.Nodes.Add(parentMenuId.ToString(), parentTitle);
                }
                node.Nodes.Clear();
                foreach (DataRow child in data.Rows)
                {
                    var childModuleId = Convert.ToInt32(child.ItemArray[2]);
                    var childMenuId = Convert.ToInt32(child.ItemArray[0]);
                    var childTitle = child.ItemArray[1].ToString();
                    if (childModuleId != 0)
                    {
                        if (childModuleId == parentMenuId)
                        {
                            node.Nodes.Add(childMenuId.ToString(), childTitle);
                        }
                    }
                }
            }

            return treeView;
        }
        public async Task<bool> OnSaveAsync(string id)
        {
            return await _userAccessService.SaveAsync(_ids, id);
        }
    }
}
