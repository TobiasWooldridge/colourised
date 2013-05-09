using System;

namespace Colourised.Driver
{
    public class Channel
    {
        public SmoothBehavior Behavior { get; set; }

        public Channel()
        {
            Behavior = new SmoothBehavior { Target = 0 };
        }

        public double Current
        {
            get { return Behavior.DeviceValue; }
        }

        public byte CurrentByte
        {
            get { return Behavior.DeviceValueByte; }
        }
    }
}