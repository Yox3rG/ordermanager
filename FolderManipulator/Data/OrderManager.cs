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
            activeOrders.Orders.Add(order);
        }

        public static void AddNewOrders(OrderData[] orders)
        {
            for (int i = 0; i < orders.Length; i++)
            {
                activeOrders.Orders.Add(orders[i]);
            }
        }

        public static bool RemoveActiveOrder(OrderData order)
        {
            return activeOrders.Orders.Remove(order);
        }

        //public static void EditActiveOrder(OrderData order, OrderData other)
        //{
        //    order.Copy(other);
        //}

        public static bool FinishOrder(OrderData order)
        {
            if (activeOrders.Orders.Remove(order))
            {
                finishedOrders.Orders.Add(order);
            }
            else if (pendingOrders.Orders.Remove(order))
            {
                finishedOrders.Orders.Add(order);
            }
            else
            {
                return false;
            }
            return true;
        }

        public static bool AddOrderToPending(OrderData order)
        {
            if (activeOrders.Orders.Remove(order))
            {
                pendingOrders.Orders.Add(order);
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
            activeOrders.Orders.Clear();
            pendingOrders.Orders.Clear();
            finishedOrders.Orders.Clear();
        }

        public static void InitializeOrders()
        {
            activeOrders = new OrderList(new List<OrderData>(), OrderListType.Active);
            pendingOrders = new OrderList(new List<OrderData>(), OrderListType.Active);
            finishedOrders = new OrderList(new List<OrderData>(), OrderListType.Finished);
        }

        public static void InitializeOrders(OrderList active, OrderList pending, OrderList finished)
        {
            activeOrders = active;
            pendingOrders = pending;
            finishedOrders = finished;

            if (activeOrders == null)
                activeOrders = new OrderList(new List<OrderData>(), OrderListType.Active);
            if (pendingOrders == null)
                pendingOrders = new OrderList(new List<OrderData>(), OrderListType.Pending);
            if (finishedOrders == null)
                finishedOrders = new OrderList(new List<OrderData>(), OrderListType.Finished);
        }
    }
}
