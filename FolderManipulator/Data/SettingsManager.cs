using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    static class SettingsManager
    {
        public static Action OnSettingsChanged;
        public static SettingsData Settings { get; set; }

        public static void AddNewOrderType(string orderType, OrderCategory category)
        {
            Settings.GetOrderTypesFromCategory(category).list.Add(orderType);
            OnSettingsChanged?.Invoke();
        }

        public static bool DeleteOrderType(string orderType, OrderCategory category)
        {
            bool isSuccess = !Settings.GetOrderTypesFromCategory(category).list.Remove(orderType);
            OnSettingsChanged?.Invoke();
            if (isSuccess)
                return true;
            else
                return false;
        }

        public static List<string> GetOrderTypes(OrderCategory category)
        {
            return Settings.GetOrderTypesFromCategory(category).list;
        }

        public static void InitializeSettings(SettingsData settingsData)
        {
            if (settingsData == null)
            {
                Settings = new SettingsData();
            }
            else
            {
                Settings = settingsData;
            }
        }
    }
}
