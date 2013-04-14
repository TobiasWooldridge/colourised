using System;
using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver
{
    public class Channel
    {
        public ChannelBehavior.ChannelBehavior Behavior { get; set; }

        public Channel()
        {
            Behavior = new ImmediateBehavior { Target = 0 };
        }

        public UInt16 Current
        {
            get { return Behavior.DeviceValue; }
        }
    }
}