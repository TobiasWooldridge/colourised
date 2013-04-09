using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SplashPixel.Hardware;

namespace SplashPixel.Gui
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Controller _controller;
        private readonly List<Device> _devices;

        public MainWindow()
        {
            InitializeComponent();

            //var port = new SerialPort("COM3", 115200);

            //_controller = new SerialController(port);
            _controller = new VirtualController();

            _devices = new List<Device>();

            UpdateDeviceList();

            Application.Current.Exit += Exit;
        }

        private void Exit(object sender, ExitEventArgs exitEventArgs)
        {
            _controller.ShutDown();
        }

        public void UpdateDeviceList()
        {
            _devices.Add(new RgbDevice("Top", _controller.Channels[6], _controller.Channels[7], _controller.Channels[8]));
            _devices.Add(new RgbDevice("Right", _controller.Channels[9], _controller.Channels[10],
                                       _controller.Channels[11]));
            _devices.Add(new RgbDevice("Bottom", _controller.Channels[2], _controller.Channels[0],
                                       _controller.Channels[1]));
            _devices.Add(new RgbDevice("Left", _controller.Channels[5], _controller.Channels[4], _controller.Channels[3]));
            _devices.AddRange(_controller.Channels.Select((t, i) => new SimpleAnalogDevice("Channel " + i, t)));

            Debug.Assert(DevicePicker != null, "DevicePicker != null");
            while (DevicePicker.Items.Count > 0)
            {
                DevicePicker.Items.RemoveAt(0);
            }

            foreach (Device device in _devices)
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
                control = new RgbDeviceControl((RgbDevice) newValue);
            }
            else if (newValue is SimpleAnalogDevice)
            {
                control = new SimpleAnalogDeviceControl((SimpleAnalogDevice) newValue);
            }

            if (control != null)
            {
                control.Margin = new Thickness(10);
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
    }
}