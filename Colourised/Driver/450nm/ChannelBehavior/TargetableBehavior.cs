namespace Colourised.Driver.ChannelBehavior
{
    public abstract class TargetableBehavior : ChannelBehavior
    {
        public abstract ushort Target { get; set; }
        public byte TargetByte
        {
            get { return (byte)(Target >> 8); }
            set { Target = (ushort)(value << 8); }
        }
    }
}
