using Colourised.Driver;

namespace Colourised.UI.Wpf
{
    /// <summary>
    /// Interaction logic for SimpleRgbDeviceControl.xaml
    /// </summary>
    public partial class SimpleRgbDeviceControl
    {
        public SimpleRgbDeviceControl(RgbDevice device)
        {
            InitializeComponent();

            ColorCanvas.SelectedColor = ColorConverter.Convert(device.Color);
            ColorCanvas.SelectedColorChanged += (s, a) => device.Color = ColorConverter.Convert(a.NewValue);
        }
    }
}
