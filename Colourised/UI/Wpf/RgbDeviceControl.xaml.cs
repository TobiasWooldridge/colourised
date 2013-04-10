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

            ColorCanvas.SelectedColor = rgbDevice.TargetWmColor;
            ColorCanvas.SelectedColorChanged += (s, a) => rgbDevice.TargetWmColor = a.NewValue;
        }
    }
}
