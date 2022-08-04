using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    public class OrderEditData
    {
        public string MainOrderType { get; set; }
        public string SubOrderType { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        public OrderEditData(string mainOrderType, string subOrderType, int count, string description)
        {
            MainOrderType = mainOrderType;
            SubOrderType = subOrderType;
            Count = count;
            Description = description;
        }
    }
}
