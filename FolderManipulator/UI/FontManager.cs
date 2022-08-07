using FolderManipulator.Analytics;
using FolderManipulator.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.UI
{
    public static class FontManager
    {
        public static Action OnFontSizeChanged;

        public static Font mainOrderTypeFont;
        public static Font orderFont;
        public static int orderItemHeight;

        private static string fontName = "Consolas";

        public static void Initialize(int pixelSize)
        {
            UpdateFontSize(pixelSize);
            SettingsManager.OnOrderFontSizeChange += UpdateFontSize;
        }

        public static void UpdateFontSize(int pixelSize)
        {
            if (orderFont != null && pixelSize == orderFont.Size)
            {
                AppConsole.WriteLine($"Font size already set to {pixelSize}.");
            }

            DisposeFontIfNotNull();

            mainOrderTypeFont = new Font(fontName, pixelSize, FontStyle.Bold, GraphicsUnit.Pixel);
            orderFont = new Font(fontName, pixelSize, GraphicsUnit.Pixel);
            orderItemHeight = pixelSize + 6;

            OnFontSizeChanged?.Invoke();
        }

        public static void DisposeFontIfNotNull()
        {
            if (mainOrderTypeFont != null)
                mainOrderTypeFont.Dispose();
            if (orderFont != null)
                orderFont.Dispose();
        }
    }
}
