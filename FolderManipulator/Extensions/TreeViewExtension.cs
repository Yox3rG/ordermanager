using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
