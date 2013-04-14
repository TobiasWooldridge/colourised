using Colourised.Driver;

namespace Colourised.UI.Wpf
{
    /// <summary>
    /// Interaction logic for RgbDeviceControl.xaml
    /// </summary>
    public partial class RgbDeviceControl
    {
        public RgbDeviceControl(RgbDevice rgbDevice)
        {
            InitializeComponent();

            ColorCanvas.SelectedColor = ColorConverter.Convert(rgbDevice.Target);
            ColorCanvas.SelectedColorChanged += (s, a) => rgbDevice.Target = ColorConverter.Convert(a.NewValue);
        }
    }
}
