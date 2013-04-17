using System.Drawing;
using System.Windows.Forms;
using Colourised.Driver;

namespace Colourised.UI.WinForms
{
    public partial class MainWindow : Form
    {
        private readonly Controller _controller;

        public MainWindow()
        {
            InitializeComponent();

            _controller = new VirtualController();

            deviceList.Items.Add(new RgbDevice("Top", _controller.Channels[6], _controller.Channels[7], _controller.Channels[8]));
            deviceList.Items.Add(new RgbDevice("Right", _controller.Channels[9], _controller.Channels[10], _controller.Channels[11]));
            deviceList.Items.Add(new RgbDevice("Bottom", _controller.Channels[2], _controller.Channels[0], _controller.Channels[1]));
            deviceList.Items.Add(new RgbDevice("Left", _controller.Channels[5], _controller.Channels[4], _controller.Channels[3]));
        }
    }
}
