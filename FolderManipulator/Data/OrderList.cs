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
        public OrderListType Type { get; set; }
        public List<OrderData> Orders { get; set; }

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

            UpdateID.IncreaseUpdateID();
            Orders.Add(data);
            Orders.Sort();
            SetSpecialFieldsOnAdd(data);
        }

        public bool Remove(OrderData data)
        {
            if (data == null)
                return false;

            UpdateID.IncreaseUpdateID();
            bool success = Orders.Remove(data);
            if (success)
            {
                Orders.Sort();
            }
            return success;
        }

        public void Clear()
        {
            UpdateID.IncreaseUpdateID();
            Orders.Clear();
        }

        public List<OrderData> GetOrders(List<Guid> guids)
        {
            List<OrderData> ordersFromGuid = new List<OrderData>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (guids.Contains(Orders[i].Id))
                {
                    ordersFromGuid.Add(Orders[i]);
                }
            }
            return ordersFromGuid;
        }

        private void SetSpecialFieldsOnAdd(OrderData orderData)
        {
            switch (Type)
            {
                case OrderListType.Active:
                    orderData.State = OrderState.None;
                    break;
                case OrderListType.Pending:
                    if(orderData.State == OrderState.None)
                    {
                        orderData.State = OrderState.Pending;
                    }
                    break;
                case OrderListType.Finished:
                    orderData.State = OrderState.None;
                    orderData.FinishedDate = DateTime.Now;
                    break;
                case OrderListType.Archived:
                    orderData.State = OrderState.None;
                    break;
                default:
                    break;
            }
        }
    }

    public enum OrderListType
    {
        Active,
        Pending,
        Finished,
        Archived,
    }
}
