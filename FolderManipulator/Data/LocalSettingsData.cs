using System;

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
        public string OrdersFontName { get; set; }

        public LocalSettingsData()
        {
            SourcePath = null;
            SetFont(12, "Consolas");
            LocalDriveLetter = "M";
            OrderNameMaxLength = 40;
            Language = LanguageType.English;
            CanArchive = false;
        }

        public LocalSettingsData(string sourcePath, int pixelSize)
        {
            SourcePath = sourcePath;
            SetFont(pixelSize, "Consolas");
            LocalDriveLetter = "M";
            OrderNameMaxLength = 40;
            Language = LanguageType.English;
            CanArchive = false;
        }

        public void SetFont(int newPixelSize, string newFontName)
        {
            OrdersFontPixelSize = newPixelSize;
            if (newFontName != null)
            {
                OrdersFontName = newFontName;
            }
            SettingsManager.OnOrderFontChanged?.Invoke(OrdersFontPixelSize, OrdersFontName);
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
