using System.Drawing;

namespace Colourised.Driver.RgbDeviceBehavior
{
    class SimpleRgbBehavior : RgbBehavior
    {
        public SimpleRgbBehavior(ChannelBehavior.ChannelBehavior r, ChannelBehavior.ChannelBehavior g, ChannelBehavior.ChannelBehavior b)
            : base(r, g, b)
        {

        }

        public Color Color { get; set; }
    }
}
