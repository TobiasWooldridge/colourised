using System.Collections.Generic;
using System.Windows.Controls;
using SplashPixel.Hardware;

namespace SplashPixel.Gui
{
    /// <summary>
    /// Interaction logic for RgbDeviceControl.xaml
    /// </summary>
    public partial class RgbDeviceControl : UserControl
    {
        public RgbDeviceControl(RgbDevice rgbDevice)
        {
            InitializeComponent();

            ColorCanvas.SelectedColor = rgbDevice.TargetWmColor;
            ColorCanvas.SelectedColorChanged += (s, a) => rgbDevice.TargetWmColor = a.NewValue;;
        }
    }
}
