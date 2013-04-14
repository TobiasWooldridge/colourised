using System;
using System.Diagnostics;
using System.Drawing;
using Colourised.Driver.ChannelBehavior;

namespace Colourised.Driver
{
    public class RgbDevice : Device
    {
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
        }

        private TargetableBehavior R { get; set; }
        private TargetableBehavior G { get; set; }
        private TargetableBehavior B { get; set; }

        public Color Target
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