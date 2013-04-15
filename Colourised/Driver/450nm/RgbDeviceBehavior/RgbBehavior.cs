using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver.RgbDeviceBehavior
{
    public abstract class RgbBehavior
    {
        protected TargetableBehavior R { get; set; }
        protected TargetableBehavior G { get; set; }
        protected TargetableBehavior B { get; set; }

        protected RgbBehavior()
        {
            
        }

        public void SetChannels(TargetableBehavior r, TargetableBehavior g, TargetableBehavior b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
