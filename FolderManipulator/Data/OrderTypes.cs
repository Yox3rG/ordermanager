using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    class OrderTypes
    {
        public const string noTypeName = "(None)";

        public List<string> list { get; set; }

        public string[] GetListAsArray()
        {
            return list.ToArray();
        }

        public OrderTypes()
        {
            list = new List<string>();
        }

        public OrderTypes(List<string> _list)
        {
            list = _list;
            if (list == null)
                list = new List<string>();
        }

        public void Add(string orderType)
        {
            list.Add(orderType);
            list.Sort();
        }

        public bool Remove(string orderType)
        {
            if (list.Remove(orderType))
            {
                list.Sort();
                return true;
            }
            return false;
        }
    }

    public enum OrderCategory
    {
        Main,
        Sub,
    }
}
