using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FolderManipulator.Extensions
{
    public static class TreeViewExtension
    {
        public static T GetCurrentSelectedItem<T>(this TreeView activeOrders)
        {
            T item = (T)activeOrders.SelectedNode.Tag;
            return item;
        }

        public static List<TreeNode> GetAllNodes(this TreeView _self)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in _self.Nodes)
            {
                result.AddRange(child.GetAllNodes());
            }
            return result;
        }

        public static List<TreeNode> GetAllNodes(this TreeNode _self)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(_self);
            foreach (TreeNode child in _self.Nodes)
            {
                result.AddRange(child.GetAllNodes());
            }
            return result;
        }

        public static List<TreeNode> GetNodes(this TreeView _self, Func<TreeNode, bool> selector)
        {
            List<TreeNode> nodes = _self.GetAllNodes();
            if (selector != null)
            {
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    if (!selector(nodes[i]))
                    {
                        nodes.RemoveAt(i);
                    }
                }
            }
            return nodes;
        }
    }
}
