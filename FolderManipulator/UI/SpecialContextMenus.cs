using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderManipulator.UI
{
    internal class SpecialContextMenu<T>
    {
        private Control _owner;
        private SpecialContextMenuItem[] _items;

        public ContextMenu Menu { get; private set; }

        public SpecialContextMenu(Control owner, SpecialContextMenuItem[] items)
        {
            _owner = owner;
            _items = items;

            Menu = new ContextMenu();
            foreach (var item in _items)
            {
                MenuItem menuItemEdit = Menu.MenuItems.Add(item.Name);
                menuItemEdit.Click += (sender, e) => { item.OnClick?.Invoke(_owner); };
            }
        }
    }

    public class SpecialContextMenuItem
    {
        public string Name { get; set; }
        public Action<Control> OnClick { get; set; }

        public SpecialContextMenuItem(string name, Action<Control> onClick)
        {
            Name = name;
            OnClick = onClick;
        }
    }
}
