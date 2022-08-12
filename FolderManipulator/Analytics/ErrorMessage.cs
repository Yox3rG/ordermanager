using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Analytics
{
    [Serializable]
    public class ErrorMessage
    {
        public string ID { get; set; }
        public string Message { get; set; }
    }
}
