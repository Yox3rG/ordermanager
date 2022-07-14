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
        public Action OnOrderListChanged;

        public UpdateID UpdateID { get; set; }
        public List<OrderData> Orders { get; set; }
        public OrderListType Type { get; set; }

        public OrderList()
        {
            UpdateID = new UpdateID();
            Orders = new List<OrderData>();
            Type = OrderListType.Active;
        }

        public OrderList(int lastUpdateID, List<OrderData> list, OrderListType type)
        {
            UpdateID = new UpdateID(lastUpdateID);
            Orders = list;
            Type = type;
        }

        public void Add(OrderData data)
        {
            UpdateID.IncreaseUpdateID();
            OnOrderListChanged?.Invoke();
            Orders.Add(data);
        }

        public bool Remove(OrderData data)
        {
            UpdateID.IncreaseUpdateID();
            OnOrderListChanged?.Invoke();
            return Orders.Remove(data);
        }

        public void Clear()
        {
            UpdateID.IncreaseUpdateID();
            OnOrderListChanged?.Invoke();
            Orders.Clear(); 
        }
    }

    public enum OrderListType
    {
        Active,
        Pending,
        Finished,
    }
}
