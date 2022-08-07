using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FolderManipulator.Extensions
{
    public static class TreeViewExtension
    {
        #region DLLs
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        #endregion

        public static int GetTreeViewScrollPosVertical(this TreeView _self)
        {
            return GetScrollPos(_self.Handle, SB_VERT);
        }

        public static void SetTreeViewScrollPosVertical(this TreeView _self, int scrollPosition)
        {
            SetScrollPos(_self.Handle, SB_VERT, scrollPosition, true);
        }

        public static T GetCurrentSelectedItem<T>(this TreeView activeOrders)
        {
            if(activeOrders == null || activeOrders.SelectedNode == null)
                return default(T);

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
