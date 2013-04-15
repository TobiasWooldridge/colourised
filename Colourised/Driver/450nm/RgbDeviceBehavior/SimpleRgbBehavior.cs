using System.Drawing;

namespace Colourised.Driver.RgbDeviceBehavior
{
    public class SimpleRgbBehavior : RgbBehavior
    {
        public Color Color
        {
            get
            {
                if (HasChannels)
                {
                    return Color.FromArgb(R.TargetByte, G.TargetByte, B.TargetByte);
                }

                return Color.Black;
            }
            set
            {
                if (HasChannels)
                {
                    R.TargetByte = value.R;
                    G.TargetByte = value.G;
                    B.TargetByte = value.B;
                }
            }
        }
    }
}
