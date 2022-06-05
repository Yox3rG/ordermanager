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
        public OrderTypes mainOrderTypes { get; set; }
        public OrderTypes subOrderTypes { get; set; }
        public bool KeepCheckedFilesAfterRefresh { get; set; } = true;

        public SettingsData(OrderTypes main, OrderTypes sub)
        {
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
            mainOrderTypes = new OrderTypes();
            subOrderTypes = new OrderTypes();
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
