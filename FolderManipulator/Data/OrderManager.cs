using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    static class OrderManager
    {
        public static Func<bool> OnCanInitiateChange;
        public static Action OnOrderListChanged;

        private static OrderList activeOrders;
        private static OrderList pendingOrders;
        private static OrderList finishedOrders;

        #region HandleChanges
        public static bool CanChangeData
        {
            get
            {
                if (OnCanInitiateChange == null)
                    return true;
                return OnCanInitiateChange();
            }
        }

        private static void HandleOrderData(OrderData order, Action<OrderData> action)
        {
            if (order == null || action == null)
                return;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't add to orderlist {activeOrders.Type}");
                return;
            }
            action.Invoke(order);
            OnOrderListChanged?.Invoke();
        }

        private static void HandleOrderData(IEnumerable<OrderData> orders, Action<OrderData> action)
        {
            if (orders == null || action == null)
                return;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't add to orderlist {activeOrders.Type}");
                return;
            }
            foreach (OrderData order in orders)
            {
                action.Invoke(order);
            }
            OnOrderListChanged?.Invoke();
        }

        private static bool HandleOrderData(OrderData order, Func<OrderData, bool> func)
        {
            if (order == null || func == null)
                return false;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't add to orderlist {activeOrders.Type}");
                return false;
            }
            bool result = func.Invoke(order);
            OnOrderListChanged?.Invoke();
            return result;
        }

        private static bool HandleOrderData(IEnumerable<OrderData> orders, Func<OrderData, bool> func)
        {
            if (orders == null || func == null)
                return false;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't add to orderlist {activeOrders.Type}");
                return false;
            }
            bool result = true;
            foreach (OrderData order in orders)
            {
                if (!func.Invoke(order))
                {
                    result = false;
                }
            }
            OnOrderListChanged?.Invoke();
            return result;
        }
        #endregion

        public static void AddNewOrder(OrderData order)
        {
            HandleOrderData(order, activeOrders.Add);
        }

        public static void AddNewOrder(IEnumerable<OrderData> orders)
        {
            HandleOrderData(orders, activeOrders.Add);
        }

        public static bool RemoveActiveOrder(OrderData order)
        {
            return HandleOrderData(order, activeOrders.Remove);
        }

        public static bool RemoveActiveOrder(IEnumerable<OrderData> orders)
        {
            return HandleOrderData(orders, activeOrders.Remove);
        }

        //public static void EditActiveOrder(OrderData order, OrderData other)
        //{
        //    order.Copy(other);
        //}

        public static bool FinishOrder(OrderData order)
        {
            return HandleOrderData(order, FinishOrderFunction);
        }

        public static bool FinishOrder(IEnumerable<OrderData> orders)
        {
            return HandleOrderData(orders, FinishOrderFunction);
        }

        private static bool FinishOrderFunction(OrderData order)
        {
            if (activeOrders.Remove(order))
            {
                finishedOrders.Add(order);
                return true;
            }
            else if (pendingOrders.Remove(order))
            {
                finishedOrders.Add(order);
                return true;
            }
            return false;
        }

        public static bool AddOrderToPending(OrderData order)
        {
            return HandleOrderData(order, AddOrderToPendingFunction);
        }

        public static bool AddOrderToPending(IEnumerable<OrderData> orders)
        {
            return HandleOrderData(orders, AddOrderToPendingFunction);
        }

        private static bool AddOrderToPendingFunction(OrderData order)
        {
            if (activeOrders.Remove(order))
            {
                pendingOrders.Add(order);
                return true;
            }
            return false;
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
