using System.Drawing;

namespace Colourised.UI.Wpf
{
    internal class ColorConverter
    {
        public static Color Convert(System.Windows.Media.Color from)
        {
            return Color.FromArgb(from.A, from.R, from.G, from.B);
        }

        public static System.Windows.Media.Color Convert(Color from)
        {
            return System.Windows.Media.Color.FromArgb(from.A, from.R, from.G, from.B);
        }
    }
}