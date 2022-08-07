using FolderManipulator.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    static class SettingsManager
    {
        public static Func<bool> OnCanInitiateChange;
        public static Action OnSettingsChanged;

        public static Action<int> OnOrderFontSizeChange;

        public static bool CanChangeData
        {
            get
            {
                if (OnCanInitiateChange == null)
                    return true;
                return OnCanInitiateChange();
            }
        }

        public static SettingsData Settings { get; set; }
        public static LocalSettingsData LocalSettings { get; set; }

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

        public static void InitializeLocalSettings(LocalSettingsData localSettingsData)
        {
            if (localSettingsData == null)
            {
                LocalSettings = new LocalSettingsData();
            }
            else
            {
                LocalSettings = localSettingsData;
                FontManager.UpdateFontSize(LocalSettings.OrdersFontPixelSize);
            }
        }

        public static bool AreSettingsOnLatestUpdate(SettingsData newSettings)
        {
            bool areSettingsLatest = Settings.UpdateID.Equals(newSettings.UpdateID);
            return areSettingsLatest;
        }
    }
}
