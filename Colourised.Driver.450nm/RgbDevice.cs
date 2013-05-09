using System;
using System.Diagnostics;
using System.Drawing;

namespace Colourised.Driver
{
    public class RgbDevice
    {
        public RgbDevice(Channel r, Channel g, Channel b) : this(r, g, b, null)
        {
        }

        public RgbDevice(Channel r, Channel g, Channel b, string name)
        {
            Name = name;

            Debug.Assert(r != null && g != null && b != null, "Missing channel");

            R = new SmoothBehavior();
            r.Behavior = R;

            G = new SmoothBehavior();
            g.Behavior = G;

            B = new SmoothBehavior();
            b.Behavior = B;
        }

        private SmoothBehavior R { get; set; }
        private SmoothBehavior G { get; set; }
        private SmoothBehavior B { get; set; }


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


        private String _name;
        public String Name
        {
            get
            {
                return _name ?? "Unnamed RGB Device";
            }
            set
            {
                _name = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}