using System.Diagnostics;
using System.Drawing;

namespace SplashPixel.Hardware
{
    public class RgbDevice : Device
    {
        public RgbDevice(string name, Channel r, Channel g, Channel b) : base(name)
        {
            Debug.Assert(name != null, "Missing name");

            Debug.Assert(r != null && g != null && b != null, "Missing channel");

            R = r;
            G = g;
            B = b;
        }

        private Channel R { get; set; }
        private Channel G { get; set; }
        private Channel B { get; set; }

        public Color CurrentColor
        {
            get { return Color.FromArgb(R.TargetByte, G.TargetByte, B.TargetByte); }
            set
            {
                R.Target = value.R;
                G.Target = value.G;
                B.Target = value.B;
            }
        }

        public System.Windows.Media.Color CurrentWmColor
        {
            get { return System.Windows.Media.Color.FromArgb(255, R.CurrentByte, G.CurrentByte, B.CurrentByte); }
        }

        public System.Windows.Media.Color TargetWmColor
        {
            get { return System.Windows.Media.Color.FromArgb(255, R.TargetByte, G.TargetByte, B.TargetByte); }
            set
            {
                R.TargetByte = value.R;
                G.TargetByte = value.G;
                B.TargetByte = value.B;
            }
        }

    }
}