using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    public class TreeViewHandleGroup
    {
        private List<TreeViewHandle> handles;
        private Dictionary<TreeView, TreeViewHandle> treeViewToHandle;

        public TreeViewHandleGroup()
        {
            handles = new List<TreeViewHandle>();
            treeViewToHandle = new Dictionary<TreeView, TreeViewHandle>();
        }

        public void AddHandle(TreeViewHandle handle)
        {
            handles.Add(handle);
            treeViewToHandle[handle.TreeView] = handle;
        }

        public bool RemoveHandle(TreeViewHandle handle)
        {
            bool success = treeViewToHandle.Remove(handle.TreeView);
            return handles.Remove(handle) && success;
        }

        public TreeViewHandle GetHandle(TreeView treeView)
        {
            if (treeViewToHandle.TryGetValue(treeView, out TreeViewHandle handle))
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
