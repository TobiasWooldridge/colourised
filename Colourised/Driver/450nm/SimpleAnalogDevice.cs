using System;
using System.Diagnostics;
using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver
{
    public class SimpleAnalogDevice : Device
    {
        public SimpleAnalogDevice(string name, Channel c)
            : base(name)
        {
            Debug.Assert(name != null, "name != null");
            Debug.Assert(c != null, "c != null");

            ChannelBehavior = new ImmediateBehavior();
            c.Behavior = ChannelBehavior;

        }

        private TargetableBehavior ChannelBehavior { get; set; }

        public UInt16 Target
        {
            set { ChannelBehavior.Target = value; }
            get { return ChannelBehavior.Target; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
