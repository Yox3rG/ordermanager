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
        private static OrderList finishedOrders;

        public static void AddNewOrder(OrderData order)
        {
            activeOrders.Orders.Add(order);
        }

        public static bool FinishOrder(OrderData order)
        {
            if (activeOrders.Orders.Remove(order))
            {
                finishedOrders.Orders.Add(order);
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

        public static OrderList GetFinishedOrders()
        {
            return finishedOrders;
        }

        public static void ClearOrders()
        {
            activeOrders.Orders.Clear();
            finishedOrders.Orders.Clear();
        }

        public static void InitializeOrders()
        {
            activeOrders = new OrderList(new List<OrderData>(), OrderListType.Active);
            finishedOrders = new OrderList(new List<OrderData>(), OrderListType.Finished);
        }

        public static void InitializeOrders(OrderList active, OrderList finished)
        {
            activeOrders = active;
            finishedOrders = finished;

            if (activeOrders == null)
                activeOrders = new OrderList(new List<OrderData>(), OrderListType.Active);
            if (finishedOrders == null)
                finishedOrders = new OrderList(new List<OrderData>(), OrderListType.Finished);
        }
    }
}
