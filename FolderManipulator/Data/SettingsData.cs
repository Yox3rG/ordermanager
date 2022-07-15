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
            GetOrderTypesFromCategory(category).list.Add(orderType);
            UpdateID.IncreaseUpdateID();
            SettingsManager.OnSettingsChanged?.Invoke();
        }

        public bool DeleteOrderType(string orderType, OrderCategory category)
        {
            bool isSuccess = GetOrderTypesFromCategory(category).list.Remove(orderType);
            UpdateID.IncreaseUpdateID();
            SettingsManager.OnSettingsChanged?.Invoke();
            if (isSuccess)
                return true;
            else
                return false;
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
    }
}
