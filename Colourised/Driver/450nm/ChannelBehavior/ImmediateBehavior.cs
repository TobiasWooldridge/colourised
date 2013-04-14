namespace Colourised.Driver.ChannelBehavior
{
    class ImmediateBehavior : TargetableBehavior
    {
        public ImmediateBehavior()
        {
            Target = 0;
        }

        public override ushort DeviceValue {
            get { return Target; }
        }

        public override ushort Target { get; set; }
    }
}
