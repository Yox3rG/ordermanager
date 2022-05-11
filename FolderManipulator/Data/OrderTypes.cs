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
    }

    public enum OrderCategory
    {
        Main,
        Sub,
    }
}
