using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    static class OrderManager
    {
        private static OrderList activeOrders;
        private static OrderList pendingOrders;
        private static OrderList finishedOrders;

        public static void AddNewOrder(OrderData order)
        {
            activeOrders.Add(order);
        }

        public static void AddNewOrders(OrderData[] orders)
        {
            for (int i = 0; i < orders.Length; i++)
            {
                activeOrders.Add(orders[i]);
            }
        }

        public static bool RemoveActiveOrder(OrderData order)
        {
            return activeOrders.Remove(order);
        }

        //public static void EditActiveOrder(OrderData order, OrderData other)
        //{
        //    order.Copy(other);
        //}

        public static bool FinishOrder(OrderData order)
        {
            if (activeOrders.Remove(order))
            {
                finishedOrders.Add(order);
            }
            else if (pendingOrders.Remove(order))
            {
                finishedOrders.Add(order);
            }
            else
            {
                return false;
            }
            return true;
        }

        public static bool AddOrderToPending(OrderData order)
        {
            if (activeOrders.Remove(order))
            {
                pendingOrders.Add(order);
            }
            else
            {
                return false;
            }
            return true;
        }

        public static OrderList GetActiveOrders()
        {
            return activeOrders;
        }
        
        public static OrderList GetPendingOrders()
        {
            return pendingOrders;
        }

        public static OrderList GetFinishedOrders()
        {
            return finishedOrders;
        }

        public static void ClearOrders()
        {
            activeOrders.Clear();
            pendingOrders.Clear();
            finishedOrders.Clear();
        }

        public static void InitializeOrders()
        {
            activeOrders = new OrderList(0, new List<OrderData>(), OrderListType.Active);
            pendingOrders = new OrderList(0, new List<OrderData>(), OrderListType.Active);
            finishedOrders = new OrderList(0, new List<OrderData>(), OrderListType.Finished);
        }

        public static void InitializeOrders(OrderList active, OrderList pending, OrderList finished)
        {
            activeOrders = active;
            pendingOrders = pending;
            finishedOrders = finished;

            if (activeOrders == null)
                activeOrders = new OrderList(0, new List<OrderData>(), OrderListType.Active);
            if (pendingOrders == null)
                pendingOrders = new OrderList(0, new List<OrderData>(), OrderListType.Pending);
            if (finishedOrders == null)
                finishedOrders = new OrderList(0, new List<OrderData>(), OrderListType.Finished);
        }

        public static bool AreOrdersOnLatestUpdate(OrderList newActive, OrderList newPending, OrderList newFinished)
        {
            bool isEveryOrderLatest = 
                activeOrders.UpdateID.Equals(newActive.UpdateID) &&
                pendingOrders.UpdateID.Equals(newPending.UpdateID) &&
                finishedOrders.UpdateID.Equals(newFinished.UpdateID);
            return isEveryOrderLatest;
        }
    }
}
