using System;
using System.Diagnostics;

namespace Colourised.Hardware
{
    public class SimpleAnalogDevice : Device
    {
        public SimpleAnalogDevice(string name, Channel c) : base(name)
        {
            Debug.Assert(name != null, "name != null");
            Debug.Assert(c != null, "c != null");

            Channel = c;
        }

        private Channel Channel { get; set; }

        public UInt16 CurrentValue
        {
            get { return Channel.Current; }
        }

        public UInt16 TargetValue
        {
            set { Channel.Target = value; }
            get { return Channel.Target; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
