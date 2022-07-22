using FolderManipulator.Analytics;
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
        public DataType DataType
        {
            get
            {
                switch (Type)
                {
                    case OrderListType.Active:
                        return DataType.ActiveOrders;
                    case OrderListType.Pending:
                        return DataType.PendingOrders;
                    case OrderListType.Finished:
                        return DataType.FinishedOrders;
                    default:
                        return DataType.ActiveOrders;
                }
            }
        }

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
            if (data == null)
                return;
            if (!OrderManager.CanChangeData)
            {
                AppConsole.WriteLine($"Can't add data to orderlist {Type}");
                return;
            }

            UpdateID.IncreaseUpdateID();
            Orders.Add(data);
            OrderManager.OnOrderListChanged?.Invoke(this);
        }

        public bool Remove(OrderData data)
        {
            if (data == null)
                return false;
            if (!OrderManager.CanChangeData)
            {
                AppConsole.WriteLine($"Can't remove data from orderlist {Type}");
                return false;
            }

            UpdateID.IncreaseUpdateID();
            bool success = Orders.Remove(data);
            OrderManager.OnOrderListChanged?.Invoke(this);
            return success;
        }

        public void Clear()
        {
            if (!OrderManager.CanChangeData)
            {
                AppConsole.WriteLine($"Can't clear data from orderlist {Type}");
                return;
            }

            UpdateID.IncreaseUpdateID();
            Orders.Clear();
            OrderManager.OnOrderListChanged?.Invoke(this);
        }
    }

    public enum OrderListType
    {
        Active,
        Pending,
        Finished,
    }
}
