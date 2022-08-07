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

        public LocalSettingsData()
        {
            SourcePath = null;
            SetPixelSize(12);
        }

        public LocalSettingsData(string sourcePath, int pixelSize)
        {
            SourcePath = sourcePath;
            SetPixelSize(pixelSize);
        }

        public void SetPixelSize(int newPixelSize)
        {
            OrdersFontPixelSize = newPixelSize;
            SettingsManager.OnOrderFontSizeChange?.Invoke(OrdersFontPixelSize);
        }
    }
}
