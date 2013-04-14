using System;

namespace Colourised.Driver.ChannelBehavior
{
    public abstract class ChannelBehavior
    {
        public abstract ushort DeviceValue { get; }
        public byte DeviceValueByte
        {
            get { return (byte)(DeviceValue >> 8); }
        }
    }
}