using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YuragiMemo
{
    public static class ColorDatas
    {
        public static ColorData InkBlue { get; } = new ColorData(Color.FromRgb(0x00, 0x3F, 0x8E), Colors.White);
        public static ColorData Canary { get; } = new ColorData(Color.FromRgb(0xFF, 0xF4, 0x62), Colors.Black);
        public static ColorData Rose { get; } = new ColorData(Color.FromRgb(0xE9, 0x54, 0x64), Colors.White);
        public static ColorData AppleGreen { get; } = new ColorData(Color.FromRgb(0xA7, 0xD2, 0x8D), Colors.White);
        public static ColorData White { get; } = new ColorData(Colors.White, Colors.Black);
        public static ColorData Black { get; } = new ColorData(Colors.Black, Colors.White);
    }
}
