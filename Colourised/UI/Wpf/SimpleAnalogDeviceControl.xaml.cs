using System;
using System.Diagnostics;
using System.Windows.Controls;
using Colourised.Driver;

namespace Colourised.UI.Wpf
{
    /// <summary>
    /// Interaction logic for SimpleAnalogDeviceControl.xaml
    /// </summary>
    public partial class SimpleAnalogDeviceControl
    {
        public SimpleAnalogDeviceControl(SimpleAnalogDevice device)
        {
            InitializeComponent();

            Debug.Assert(device != null, "Device != null");

            FakeAnalogSlider.Value = device.Target;
            FakeAnalogSlider.ValueChanged += (sender, args) => device.Target = (UInt16)args.NewValue;
        }
    }
}
