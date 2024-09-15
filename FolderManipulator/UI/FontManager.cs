using FolderManipulator.Analytics;
using FolderManipulator.Data;
using System;
using System.Drawing;

namespace FolderManipulator.UI
{
    public static class FontManager
    {
        public static Action OnFontSizeChanged;

        public static Font mainOrderTypeFont;
        public static Font orderFont;
        public static int orderItemHeight;

        //private static string fontName = "Lucida Console";
        //private static string fontName = "Arial";
        private static string fontName = "Consolas";

        public static void Initialize(int pixelSize, string fontName)
        {
            UpdateFont(pixelSize, fontName == null ? FontManager.fontName : fontName);
            SettingsManager.OnOrderFontChanged += UpdateFont;
        }

        public static void UpdateFont(int pixelSize, string fontName)
        {
            if (orderFont != null && pixelSize == orderFont.Size)
            {
                AppConsole.WriteLine($"trySetSameFontSize", list: pixelSize.ToString());
            }

            if (fontName == null)
            {
                fontName = FontManager.fontName;
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
