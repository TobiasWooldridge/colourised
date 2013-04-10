namespace Colourised.Hardware
{
    public abstract class Device
    {
        protected Device(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
