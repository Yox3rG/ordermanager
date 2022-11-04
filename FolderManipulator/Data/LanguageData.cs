using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    public class LanguageData : IComparable<LanguageData>
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public LanguageData(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public int CompareTo(LanguageData other)
        {
            int nameComparison = Name.CompareTo(other.Name);
            if (nameComparison != 0)
                return nameComparison;
            return Text.CompareTo(other.Text);
        }
    }
}
