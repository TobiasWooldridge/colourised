namespace Colourised.Driver.ChannelBehavior
{
    abstract class TargetableBehavior : ChannelBehavior
    {
        public abstract ushort Target { get; set; }
        public byte TargetByte
        {
            get { return (byte)(Target >> 8); }
            set { Target = (ushort)((ushort)value << 8); }
        }
    }
}
