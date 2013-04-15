using System;
using System.Diagnostics;
using System.Drawing;
using Colourised.Driver.ChannelBehavior;
using Colourised.Driver.RgbDeviceBehavior;

namespace Colourised.Driver
{
    public class RgbDevice : Device
    {
        private RgbBehavior _behavior;
        public RgbBehavior Behavior
        {
            set
            {
                value.SetChannels(R, G, B);
                _behavior = value;
            }
            get { return _behavior; }
        }

        public RgbDevice(string name, Channel r, Channel g, Channel b)
            : base(name)
        {
            Debug.Assert(name != null, "Missing name");

            Debug.Assert(r != null && g != null && b != null, "Missing channel");

            R = new ImmediateBehavior();
            r.Behavior = R;

            G = new ImmediateBehavior();
            g.Behavior = G;

            B = new ImmediateBehavior();
            b.Behavior = B;

            
            Behavior = new SimpleRgbBehavior();
        }

        private TargetableBehavior R { get; set; }
        private TargetableBehavior G { get; set; }
        private TargetableBehavior B { get; set; }


    }
}