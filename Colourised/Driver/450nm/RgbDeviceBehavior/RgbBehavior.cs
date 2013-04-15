using System;
using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver.RgbDeviceBehavior
{
    public abstract class RgbBehavior
    {
        protected TargetableBehavior R { get; set; }
        protected TargetableBehavior G { get; set; }
        protected TargetableBehavior B { get; set; }

        protected bool HasChannels = false;

        protected RgbBehavior()
        {
        }

        public void SetChannels(TargetableBehavior r, TargetableBehavior g, TargetableBehavior b)
        {
            if (r == null || g == null || b == null)
            {
                throw new ArgumentNullException("Channels cannot be null");
            }

            R = r;
            G = g;
            B = b;

            HasChannels = true;
        }

        public void ReleaseChannels()
        {
            R = null;
            G = null;
            B = null;
        }
    }
}
