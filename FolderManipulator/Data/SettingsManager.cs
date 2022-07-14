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

        public static bool AreSettingsOnLatestUpdate(SettingsData newSettings)
        {
            bool areSettingsLatest = Settings.UpdateID.Equals(newSettings.UpdateID);
            return areSettingsLatest;
        }
    }
}
