using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using SplashPixel.Hardware;

namespace SplashPixel.Gui
{
    /// <summary>
    ///     Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        private readonly Controller _controller;
        private readonly List<Device> _devices;

        public ConfigurationWindow(Controller controller, List<Device> devices)
        {
            InitializeComponent();

            _controller = controller;


            Debug.Assert(devices != null, "devices != null");
            _devices = devices;

        }

        public List<Device> Devices
        {
            get { return _devices; }
        }
    }
}