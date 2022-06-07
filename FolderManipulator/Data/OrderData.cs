﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    class OrderData
    {
        public Guid Id { get; set; }
        public string MainOrderType { get; set; }
        public string SubOrderType { get; set; }
        public string FullPath { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

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
        }

        public void Copy(OrderData other)
        {
            this.MainOrderType = other.MainOrderType;
            this.SubOrderType  = other.SubOrderType;
            this.FullPath      = other.FullPath;
            this.Count         = other.Count;       
            this.Description   = other.Description;
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
    }
}
