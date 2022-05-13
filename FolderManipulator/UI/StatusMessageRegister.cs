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
        private static Action SaveOrderListPartialSuccessAction;
        private static Action SaveOrderListFailedAction;

        // List<ActionToSubTo, ActionToAdd> ??

        public static void Initialize()
        {
            RegisterMessageForSaveOrderListSuccessful();
            RegisterMessageForSaveOrderListPartialSuccess();
            RegisterMessageForSaveOrderListFailed();
        }

        public static void RegisterMessageForSaveOrderListSuccessful()
        {
            SaveOrderListSuccessfulAction = delegate { StatusManager.ShowMessage("Mentés sikeres.", StatusColorType.Success, resetAfter: DelayTimeType.Medium); };
            PersistentData.OnSaveAllWaitingItems_Successful += SaveOrderListSuccessfulAction;
        }

        public static void RegisterMessageForSaveOrderListPartialSuccess()
        {
            SaveOrderListPartialSuccessAction = delegate { StatusManager.ShowMessage("Mentés részlegesen sikeres.", StatusColorType.Warning); };
            PersistentData.OnSaveAllWaitingItems_PartialSuccess += SaveOrderListPartialSuccessAction;
        }

        public static void RegisterMessageForSaveOrderListFailed()
        {
            SaveOrderListFailedAction = delegate { StatusManager.ShowMessage("Mentés sikertelen. Újrapróbálkozás...", StatusColorType.Error); };
            PersistentData.OnSaveAllWaitingItems_Failed += SaveOrderListFailedAction;
        }
    }
}
