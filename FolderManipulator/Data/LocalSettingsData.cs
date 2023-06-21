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
        public int OrderNameMaxLength { get; set; }
        public string LocalDriveLetter { get; set; }
        public LanguageType Language { get; set; }
        public bool CanArchive { get; set; }

        public LocalSettingsData()
        {
            SourcePath = null;
            SetPixelSize(12);
            LocalDriveLetter = "M";
            OrderNameMaxLength = 40;
            Language = LanguageType.English;
            CanArchive = false;
        }

        public LocalSettingsData(string sourcePath, int pixelSize)
        {
            SourcePath = sourcePath;
            SetPixelSize(pixelSize);
            LocalDriveLetter = "M";
            OrderNameMaxLength = 40;
            Language = LanguageType.English;
            CanArchive = false;
        }

        public void SetPixelSize(int newPixelSize)
        {
            OrdersFontPixelSize = newPixelSize;
            SettingsManager.OnOrderFontSizeChanged?.Invoke(OrdersFontPixelSize);
        }

        public void SetLanguage(LanguageType language)
        {
            Language = language;
        }

        public void SetLocalDriveLetter(string newLetter)
        {
            LocalDriveLetter = newLetter;
        }

        public void SetOrderNameMaxLength(int newLength)
        {
            OrderNameMaxLength = newLength;
            SettingsManager.OnOrderNameMaxLengthChanged?.Invoke(OrderNameMaxLength);
        }

        public void SetCanArchive(bool canArchive)
        {
            CanArchive = canArchive;
        }
    }
}
