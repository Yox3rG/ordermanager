using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Data
{
    [Serializable]
    public class LocalSettingsData
    {
        public string SourcePath { get; set; }
        public int OrdersFontPixelSize { get; set; }
        public string LocalDriveLetter { get; set; }
        public LanguageType Language { get; set; }

        public LocalSettingsData()
        {
            SourcePath = null;
            SetPixelSize(12);
            LocalDriveLetter = "M";
            Language = LanguageType.English;
        }

        public LocalSettingsData(string sourcePath, int pixelSize)
        {
            SourcePath = sourcePath;
            SetPixelSize(pixelSize);
            LocalDriveLetter = "M";
            Language = LanguageType.English;
        }

        public void SetPixelSize(int newPixelSize)
        {
            OrdersFontPixelSize = newPixelSize;
            SettingsManager.OnOrderFontSizeChange?.Invoke(OrdersFontPixelSize);
        }

        public void SetLanguage(LanguageType language)
        {
            Language = language;
        }

        public void SetLocalDriveLetter(string newLetter)
        {
            LocalDriveLetter = newLetter;
        }
    }
}
