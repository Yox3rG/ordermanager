﻿using FolderManipulator.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    class SettingsData : ISavableData
    {
        public DataType DataType { get { return DataType.Settings; } }

        public UpdateID UpdateID { get; set; }
        
        public OrderTypes mainOrderTypes { get; set; }
        public OrderTypes subOrderTypes { get; set; }
        public bool KeepCheckedFilesAfterRefresh { get; set; } = true;

        public SettingsData(int lastUpdateID, OrderTypes main, OrderTypes sub)
        {
            UpdateID = new UpdateID(lastUpdateID);
            mainOrderTypes = main;
            subOrderTypes = sub;

            if(mainOrderTypes == null)
            {
                mainOrderTypes = new OrderTypes();
            }
            if(subOrderTypes == null)
            {
                subOrderTypes = new OrderTypes();
            }
        }

        public SettingsData()
        {
            UpdateID = new UpdateID();
            mainOrderTypes = new OrderTypes();
            subOrderTypes = new OrderTypes();
        }

        public void AddNewOrderType(string orderType, OrderCategory category)
        {
            if (!SettingsManager.CanChangeData)
            {
                SettingsManager.OnCantChangeData($"cantAddOrderType");
                return;
            }
            GetOrderTypesFromCategory(category).Add(orderType);
            UpdateID.IncreaseUpdateID();
            SettingsManager.OnSettingsChanged?.Invoke();
        }

        public bool DeleteOrderType(string orderType, OrderCategory category)
        {
            if (!SettingsManager.CanChangeData)
            {
                SettingsManager.OnCantChangeData($"cantRemoveOrderType");
                return false;
            }
            bool isSuccess = GetOrderTypesFromCategory(category).Remove(orderType);
            UpdateID.IncreaseUpdateID();
            SettingsManager.OnSettingsChanged?.Invoke();
            return isSuccess;
        }

        public OrderTypes GetOrderTypesFromCategory(OrderCategory category)
        {
            switch (category)
            {
                case OrderCategory.Main:
                    return mainOrderTypes;
                case OrderCategory.Sub:
                    return subOrderTypes;
            }
            return null;
        }

        public List<string> GetMainOrderTypeList()
        {
            List<string> list = new List<string>(mainOrderTypes.list);
            return list;
        }

        public List<string> GetSubOrderTypeList()
        {
            List<string> list = new List<string>(subOrderTypes.list);
            list.Insert(0, OrderTypes.noTypeName);
            return list;
        }
    }
}
