using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    public class LanguageDataList
    {
        public LanguageType languageType;
        public List<LanguageData> languageDatas;

        public LanguageDataList(LanguageType languageType)
        {
            this.languageType = languageType;
            this.languageDatas = null;
        }

        public LanguageDataList(LanguageType languageType, List<LanguageData> languageDatas)
        {
            this.languageType = languageType;
            this.languageDatas = languageDatas;
        }
    }

    public enum LanguageType
    {
        English,
        Hungarian,
    }
}
