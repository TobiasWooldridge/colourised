using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver.RgbDeviceBehavior
{
    abstract class RgbBehavior
    {
        ChannelBehavior.ChannelBehavior R { get; set; }
        ChannelBehavior.ChannelBehavior G { get; set; }
        ChannelBehavior.ChannelBehavior B { get; set; }

        protected RgbBehavior(ChannelBehavior.ChannelBehavior r, ChannelBehavior.ChannelBehavior g, ChannelBehavior.ChannelBehavior b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
