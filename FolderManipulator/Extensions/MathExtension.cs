using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.Extensions
{
    public static class MathExtension
    {
        public static int Clamp(this int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static float Clamp(this float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static float Lerp(float a, float b, float t)
        {
            return a * (1 - t) + b * t;
        }

        public static byte Lerp(byte a, byte b, float t)
        {
            return (byte)(a * (1 - t) + b * t);
        }

        public static Color Lerp(Color aColor, Color bColor, float t)
        {
            int r = (int)Lerp(aColor.R, bColor.R, t);
            int g = (int)Lerp(aColor.G, bColor.G, t);
            int b = (int)Lerp(aColor.B, bColor.B, t);
            int a = (int)Lerp(aColor.A, bColor.A, t);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
