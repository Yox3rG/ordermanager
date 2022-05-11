using FolderManipulator.FolderRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.UI
{
    static class StatusMessageRegister
    {
        private static Action SaveOrderListSuccessfulAction;
        private static Action SaveOrderListFailedAction;

        // List<ActionToSubTo, ActionToAdd> ??

        public static void Initialize()
        {
            RegisterMessageForSaveOrderListSuccessful();
            RegisterMessageForSaveOrderListFailed();
        }

        public static void RegisterMessageForSaveOrderListSuccessful()
        {
            SaveOrderListSuccessfulAction = delegate { StatusManager.ShowMessage("Mentés sikeres.", StatusColorType.Success, resetAfter: DelayTimeType.Medium); };
            PersistentData.OnOrderSaveSuccessful += SaveOrderListSuccessfulAction;
        }

        public static void RegisterMessageForSaveOrderListFailed()
        {
            SaveOrderListFailedAction = delegate { StatusManager.ShowMessage("Mentés sikertelen. Újrapróbálkozás...", StatusColorType.Error); };
            PersistentData.OnOrderSaveFailed += SaveOrderListFailedAction;
        }
    }
}
