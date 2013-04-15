using System.Drawing;

namespace Colourised.Driver.RgbDeviceBehavior
{
    public class SimpleRgbBehavior : RgbBehavior
    {
        public Color Color
        {
            get { return Color.FromArgb(R.TargetByte, G.TargetByte, B.TargetByte); }
            set
            {
                R.TargetByte = value.R;
                G.TargetByte = value.G;
                B.TargetByte = value.B;
            }
        }
    }
}
