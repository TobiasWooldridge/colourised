using Colourised.Driver;
using Colourised.Driver.RgbDeviceBehavior;

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

            if (rgbDevice.Behavior is SimpleRgbBehavior)
            {
                var b = (SimpleRgbBehavior)rgbDevice.Behavior; 
                ColorCanvas.SelectedColor = ColorConverter.Convert(b.Color);
                ColorCanvas.SelectedColorChanged += (s, a) => b.Color = ColorConverter.Convert(a.NewValue);
            }
        }
    }
}
