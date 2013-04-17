using System.Windows.Controls;
using Colourised.Driver.RgbDeviceBehavior;

namespace Colourised.UI.Gui
{
    /// <summary>
    ///     Interaction logic for ScreenSampleRgbDeviceControl.xaml
    /// </summary>
    public partial class ScreenSampleRgbDeviceControl : UserControl
    {
        private readonly ScreenSampleRgbBehavior _behavior;

        public ScreenSampleRgbDeviceControl(ScreenSampleRgbBehavior behavior)
        {
            InitializeComponent();

            _behavior = behavior;
        }

        public int SampleAreaX
        {
            get { return _behavior.SampleArea.X; }
            set {   }
        }

        public int SampleAreaY { get; set; }
        public int SampleAreaWidth { get; set; }
        public int SampleAreaHeight { get; set; }

        private void TextBox_PreviewTextInput_1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}