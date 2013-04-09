using System;
using System.Diagnostics;
using System.Windows.Controls;
using SplashPixel.Hardware;

namespace SplashPixel.Gui
{
    /// <summary>
    /// Interaction logic for SimpleAnalogDeviceControl.xaml
    /// </summary>
    public partial class SimpleAnalogDeviceControl : UserControl
    {
        public SimpleAnalogDeviceControl(SimpleAnalogDevice device)
        {
            InitializeComponent();

            Debug.Assert(device != null, "Device != null");

            FakeAnalogSlider.Value = device.TargetValue;
            FakeAnalogSlider.ValueChanged += (sender, args) => device.TargetValue = (UInt16)args.NewValue;
        }
    }
}
