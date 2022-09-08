using FolderManipulator.Extensions;
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
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public OrderState State { get; set; }

        private static string toStringBaseNormal;
        private static string toStringBaseWithFinishedDate;

        public OrderData()
        {
            Id = Guid.NewGuid();
        }

        public static void UpdateToStringBase(int maxFileNameLength, int maxDescriptionLength)
        {
            maxFileNameLength = Math.Max(maxFileNameLength, 10);
            maxDescriptionLength = Math.Max(maxDescriptionLength, 10);

            toStringBaseNormal = "{0,-" + maxFileNameLength + "} | {1,-8} | {2,-" + maxDescriptionLength + "} | {3,-22}";
            toStringBaseWithFinishedDate = "{0,-" + maxFileNameLength + "} | {1,-8} | {2,-" + maxDescriptionLength + "} | {3,-22} | {4,-22}";
        }

        public OrderData(string mainOrderType, string subOrderType, string fullPath, int count, string customerName, string description) : this()
        {
            this.MainOrderType = mainOrderType;
            this.SubOrderType = subOrderType;
            this.FullPath = fullPath;
            this.Count = count;
            this.CustomerName = customerName;
            this.Description = description;
            this.BirthDate = DateTime.Now;
            this.State = OrderState.None;
        }

        public void Edit(OrderEditData editData)
        {
            this.MainOrderType = editData.MainOrderType;
            this.SubOrderType  = editData.SubOrderType;
            this.Count         = editData.Count;
            this.CustomerName  = editData.CustomerName;
            this.Description   = editData.Description;
        }

        public void Edit(string mainOrderType, string subOrderType, int count, string customerName, string description)
        {
            this.MainOrderType = mainOrderType;
            this.SubOrderType  = subOrderType;
            this.Count         = count;       
            this.CustomerName  = customerName;
            this.Description   = description;
        }

        public void Copy(OrderData other)
        {
            this.MainOrderType = other.MainOrderType;
            this.SubOrderType  = other.SubOrderType;
            this.FullPath      = other.FullPath;
            this.Count         = other.Count;       
            this.CustomerName  = other.CustomerName;
            this.Description   = other.Description;
            this.BirthDate     = other.BirthDate;
            this.FinishedDate  = other.FinishedDate;
            this.State         = other.State;
        }

        public string GetFileName()
        {
            return Path.GetFileName(FullPath);
        }

        public string GetFileName(int maxLength)
        {
            string fileName = GetFileName();
            if (fileName.Length > maxLength)
            {
                string extension = fileName.Substring(fileName.IndexOf('.'));
                fileName = fileName.Substring(0, maxLength - extension.Length - 2);
                fileName += "..";
                fileName += extension;
            }
            return fileName;
        }

        public string GetDirectoryName()
        {
            return Path.GetDirectoryName(FullPath);
        }

        public string GetLimitedString(string text, int maxLength)
        {
            if (text == null)
                return "";
            if (text.Length > maxLength)
            {
                text = text.Substring(0, maxLength - 3);
                text += "...";
            }
            return text;
        }

        public override string ToString()
        {
            //return $"{GetFileName()} - {Count} db {Description}";
            return String.Format("{0,-40} | {1,-8} | {2,-22} | {3}", GetFileName(), Count + " db", BirthDate.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("hu-HU")), Description);
        }

        public string ToString(int maxFileNameLength, int maxDescriptionLength, bool includeFinishedDate)
        {
            maxFileNameLength = maxFileNameLength.Clamp(10, 100);
            maxDescriptionLength = maxDescriptionLength.Clamp(10, 100);
            int customenMaxNameLength = 20;

            if (includeFinishedDate)
            {
                return String.Format("{0,-" + maxFileNameLength + "} | {1,-8} | {2,-20} | {3,-" + maxDescriptionLength + "} | {4,-22} | {5,-22}",
                    GetFileName(maxFileNameLength),
                    Count + " db",
                    GetLimitedString(CustomerName, customenMaxNameLength),
                    GetLimitedString(Description, maxDescriptionLength),
                    BirthDate.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("hu-HU")),
                    FinishedDate.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("hu-HU")));
            }
            else
            {
                return String.Format("{0,-" + maxFileNameLength + "} | {1,-8} | {2,-20} | {3,-" + maxDescriptionLength + "} | {4,-22}",
                    GetFileName(maxFileNameLength),
                    Count + " db",
                    GetLimitedString(CustomerName, customenMaxNameLength),
                    GetLimitedString(Description, maxDescriptionLength),
                    BirthDate.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("hu-HU")));
            }
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
