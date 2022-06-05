using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    public class SavableDataWithPath
    {
        public ISavableData data;
        public string path;

        public SavableDataWithPath(string path, ISavableData data)
        {
            this.path = path;
            this.data = data;
        }

        public override string ToString()
        {
            return $"Path: {path}, Data: {data}";
        }
    }
}
