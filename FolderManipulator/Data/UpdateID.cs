using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    public class UpdateID : IEquatable<UpdateID>
    {
        private const int MAX_UPDATE_VALUE = 10;

        public int Value { get; set; }

        public UpdateID()
        {
            Value = 0;
        }

        public UpdateID(int value)
        {
            Value = value;
        }

        public int IncreaseUpdateID()
        {
            if (++Value > MAX_UPDATE_VALUE)
            {
                Value = 0;
            }
            return Value;
        }

        public bool Equals(int id)
        {
            return Value == id;
        }

        public bool Equals(UpdateID other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
