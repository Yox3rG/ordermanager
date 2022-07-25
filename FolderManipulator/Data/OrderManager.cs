﻿using FolderManipulator.Analytics;
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

        private static void HandleOrderAction(OrderData order, Action<OrderData> action)
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

        private static void HandleOrderAction(IEnumerable<OrderData> orders, Action<OrderData> action)
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

        private static bool HandleOrderFunc(OrderData order, Func<OrderData, bool> func)
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

        private static bool HandleOrderFunc(IEnumerable<OrderData> orders, Func<OrderData, bool> func)
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

        private static bool HandleOrderMove(OrderData order, OrderList from, OrderList to)
        {
            if (order == null || from == null || to == null)
                return false;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't move to orderlist {activeOrders.Type}");
                return false;
            }
            bool result = MoveOrderFunction(order, from, to);
            OnOrderListChanged?.Invoke();
            return result;
        }

        private static bool HandleOrderMove(IEnumerable<OrderData> orders, OrderList from, OrderList to)
        {
            if (orders == null || from == null || to == null)
                return false;
            if (!CanChangeData)
            {
                AppConsole.WriteLine($"Can't move to orderlist {activeOrders.Type}");
                return false;
            }
            bool result = true;
            foreach (OrderData order in orders)
            {
                if (!MoveOrderFunction(order, from, to))
                {
                    result = false;
                }
            }
            OnOrderListChanged?.Invoke();
            return result;
        }

        private static bool MoveOrderFunction(OrderData order, OrderList from, OrderList to)
        {
            if (from.Remove(order))
            {
                to.Add(order);
                return true;
            }
            return false;
        }
        #endregion

        public static void AddNewOrder(OrderData order)
        {
            if (order == null)
                return;
            AppConsole.WriteLine($"Order [{order.Id}] added to active orders.");
            HandleOrderAction(order, activeOrders.Add);
        }

        public static void AddNewOrder(IEnumerable<OrderData> orders)
        {
            AppConsole.WriteLine($"Orders added to active orders.");
            HandleOrderAction(orders, activeOrders.Add);
        }

        public static bool RemoveOrder(OrderListType listType, OrderData order)
        {
            if (order == null)
                return false;
            AppConsole.WriteLine($"Order [{order.Id}] removed from [{listType}].");
            return HandleOrderFunc(order, GetOrderList(listType).Remove);
        }

        public static bool RemoveOrder(OrderListType listType, IEnumerable<OrderData> orders)
        {
            AppConsole.WriteLine($"Orders removed from [{listType}].");
            return HandleOrderFunc(orders, GetOrderList(listType).Remove);
        }

        //public static void EditActiveOrder(OrderData order, OrderData other)
        //{
        //    order.Copy(other);
        //}

        public static bool MoveOrder(OrderData order, OrderListType from, OrderListType to)
        {
            AppConsole.WriteLine($"Order [{order.Id}] from [{from}] to [{to}].");
            return HandleOrderMove(order, GetOrderList(from), GetOrderList(to));
        }

        public static bool MoveOrder(IEnumerable<OrderData> orders, OrderListType from, OrderListType to)
        {
            AppConsole.WriteLine($"Orders from [{from}] to [{to}].");
            return HandleOrderMove(orders, GetOrderList(from), GetOrderList(to));
        }

        public static OrderList GetOrderList(OrderListType type)
        {
            switch (type)
            {
                case OrderListType.Active:
                    return activeOrders;
                case OrderListType.Pending:
                    return pendingOrders;
                case OrderListType.Finished:
                    return finishedOrders;
            }
            return null;
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
