using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    class OrderList : ISavableData
    {
        public List<OrderData> Orders { get; set; }
        public OrderListType Type { get; set; }

        public OrderList()
        {
            Orders = new List<OrderData>();
            Type = OrderListType.Active;
        }

        public OrderList(List<OrderData> list, OrderListType type)
        {
            Orders = list;
            this.Type = type;
        }
    }

    public enum OrderListType
    {
        Active,
        Pending,
        Finished,
    }
}
