using Colourised.Driver;
using Colourised.Driver.RgbDeviceBehavior;

namespace Colourised.UI.Wpf
{
    /// <summary>
    /// Interaction logic for SimpleRgbDeviceControl.xaml
    /// </summary>
    public partial class SimpleRgbDeviceControl
    {
        public SimpleRgbDeviceControl(SimpleRgbBehavior behavior)
        {
            InitializeComponent();

            ColorCanvas.SelectedColor = ColorConverter.Convert(behavior.Color);
            ColorCanvas.SelectedColorChanged += (s, a) => behavior.Color = ColorConverter.Convert(a.NewValue);
        }
    }
}
