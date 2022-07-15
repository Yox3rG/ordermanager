using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    public interface ISavableData
    {
        DataType DataType { get; }
    }

    public enum DataType
    {
        Settings,
        ActiveOrders,
        PendingOrders,
        FinishedOrders,
    }

    public enum DataState
    {
        Latest,
        NotLatest,
        MissingObject,
        MissingFile,
    }
}
