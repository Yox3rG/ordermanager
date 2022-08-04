using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    public class OrderData : IComparable<OrderData>
    {
        public Guid Id { get; set; }
        public string MainOrderType { get; set; }
        public string SubOrderType { get; set; }
        public string FullPath { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public OrderState State { get; set; }

        public OrderData()
        {
            Id = Guid.NewGuid();
        }

        public OrderData(string mainOrderType, string subOrderType, string fullPath, int count, string description) : this()
        {
            this.MainOrderType = mainOrderType;
            this.SubOrderType = subOrderType;
            this.FullPath = fullPath;
            this.Count = count;
            this.Description = description;
            this.BirthDate = DateTime.Now;
            this.State = OrderState.None;
        }

        public void Edit(OrderEditData editData)
        {
            this.MainOrderType = editData.MainOrderType;
            this.SubOrderType  = editData.SubOrderType;
            this.Count         = editData.Count;
            this.Description   = editData.Description;
        }

        public void Edit(string mainOrderType, string subOrderType, int count, string description)
        {
            this.MainOrderType = mainOrderType;
            this.SubOrderType  = subOrderType;
            this.Count         = count;       
            this.Description   = description;
        }

        public void Copy(OrderData other)
        {
            this.MainOrderType = other.MainOrderType;
            this.SubOrderType  = other.SubOrderType;
            this.FullPath      = other.FullPath;
            this.Count         = other.Count;       
            this.Description   = other.Description;
            this.BirthDate     = other.BirthDate;
            this.FinishedDate  = other.FinishedDate;
            this.State         = other.State;
        }

        public string GetFileName()
        {
            return Path.GetFileName(FullPath);
        }

        public string GetDirectoryName()
        {
            return Path.GetDirectoryName(FullPath);
        }

        public override string ToString()
        {
            return $"{GetFileName()} - {Count} db {Description}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OrderData);
        }

        public bool Equals(OrderData other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public int CompareTo(OrderData other)
        {
            int difference = 0;
            difference = MainOrderType.CompareTo(other.MainOrderType);
            if (difference != 0)
                return difference;
            difference = SubOrderType.CompareTo(other.SubOrderType);
            if (difference != 0)
                return difference;
            difference = BirthDate.CompareTo(other.BirthDate);
            if (difference != 0)
                return difference;
            difference = FullPath.CompareTo(other.FullPath);
            if (difference != 0)
                return difference;
            return 0;
        }
    }

    public enum OrderState
    {
        None,
        Pending,
        Notified,
    }
}
