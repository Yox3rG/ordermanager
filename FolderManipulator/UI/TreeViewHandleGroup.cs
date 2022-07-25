using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    public class OrderTreeViewHandleGroup
    {
        private List<OrderTreeViewHandle> handles;
        private Dictionary<TreeView, OrderTreeViewHandle> treeViewToHandle;

        public OrderTreeViewHandleGroup()
        {
            handles = new List<OrderTreeViewHandle>();
            treeViewToHandle = new Dictionary<TreeView, OrderTreeViewHandle>();
        }

        public void AddHandle(OrderTreeViewHandle handle)
        {
            handles.Add(handle);
            treeViewToHandle[handle.TreeView] = handle;
        }

        public bool RemoveHandle(OrderTreeViewHandle handle)
        {
            bool success = treeViewToHandle.Remove(handle.TreeView);
            return handles.Remove(handle) && success;
        }

        public OrderTreeViewHandle GetHandle(TreeView treeView)
        {
            if (treeViewToHandle.TryGetValue(treeView, out OrderTreeViewHandle handle))
            {
                return handle;
            }
            return null;
        }

        public void ExpandAll()
        {
            foreach (var handle in handles)
            {
                handle.TreeView.ExpandAll();
            }
        }

        public void SaveCurrentScrollBarPosition()
        {
            foreach (var handle in handles)
            {
                handle.SaveCurrentScrollBarPosition();
            }
        }

        public void ResetToSavedScrollBarPosition()
        {
            foreach (var handle in handles)
            {
                handle.ResetToSavedScrollBarPosition();
            }
        }
    }
}
