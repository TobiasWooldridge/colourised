using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Colourised.Driver;

namespace Colourised.UI.Wpf
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Controller _controller;
        private readonly List<RgbDevice> _devices;

        public MainWindow()
        {
            InitializeComponent();

            //var port = new SerialPort("COM3", 115200);

            //_controller = new SerialController(port);
            _controller = new VirtualController();

            _devices = new List<RgbDevice>();

            UpdateDeviceList();

            Application.Current.Exit += Exit;
        }

        private void Exit(object sender, ExitEventArgs exitEventArgs)
        {
            _controller.ShutDown();
        }

        public void UpdateDeviceList()
        {
            _devices.Add(new RgbDevice(_controller.Channels[6], _controller.Channels[7], _controller.Channels[8], "Top"));
            _devices.Add(new RgbDevice(_controller.Channels[9], _controller.Channels[10],
                                       _controller.Channels[11], "Right"));
            _devices.Add(new RgbDevice(_controller.Channels[2], _controller.Channels[0],
                                       _controller.Channels[1], "Bottom"));
            _devices.Add(new RgbDevice(_controller.Channels[5], _controller.Channels[4], _controller.Channels[3], "Left"));


            Debug.Assert(DevicePicker != null, "DevicePicker != null");
            while (DevicePicker.Items.Count > 0)
            {
                DevicePicker.Items.RemoveAt(0);
            }

            foreach (RgbDevice device in _devices)
            {
                DevicePicker.Items.Add(device);
            }

            DevicePicker.SelectedIndex = 0;

            _controller.StartUpdates();
        }

        private void Devices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Assert(e.AddedItems.Count - e.RemovedItems.Count <= 1, "Too many items selected");

            if (e.AddedItems.Count == 0)
            {
                GenericDeviceControl.Content = null;
                return;
            }

            object newValue = e.AddedItems[0];

            Control control = null;

            if (newValue is RgbDevice)
            {
                var device = (RgbDevice)newValue;
                control = new SimpleRgbDeviceControl(device);
            }

            GenericDeviceControl.Content = control;
        }

        private void RemoveDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            int index = DevicePicker.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            DevicePicker.Items.RemoveAt(index);

            if (DevicePicker.Items.Count - 1 >= index)
            {
                DevicePicker.SelectedIndex = index;
            }
            else if (DevicePicker.Items.Count > 0)
            {
                DevicePicker.SelectedIndex = index - 1;
            }
        }

        private void AddDeviceButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}