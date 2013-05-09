using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Colourised.Driver;
using Colourised.Util;

namespace Colourised.Service
{
    class Program
    {
        private static readonly List<ScreenSampleSpecification> SampleSpecifications  = new List<ScreenSampleSpecification>();

        public static void Main(string[] args)
        {
            Controller _controller = new VirtualController();

            SampleSpecifications.Add(new ScreenSampleSpecification(
                _controller.RgbDevices[0],
                new Rectangle(100, 100, Screen.PrimaryScreen.Bounds.Width - 200, 100),
                "Top"
            ));

            SampleSpecifications.Add(new ScreenSampleSpecification(
                _controller.RgbDevices[1],
                new Rectangle(100, 100, 100, Screen.PrimaryScreen.Bounds.Height - 200),
                "Right"
            ));

            SampleSpecifications.Add(new ScreenSampleSpecification(
                _controller.RgbDevices[2],
                new Rectangle(100, 1240, Screen.PrimaryScreen.Bounds.Width - 200, 100),
                "Bottom"
            ));

            SampleSpecifications.Add(new ScreenSampleSpecification(
                _controller.RgbDevices[3],
                new Rectangle(2360, 100, 100, Screen.PrimaryScreen.Bounds.Height - 200),
                "Left"
            ));


            try
            {
                _controller.StartUpdates();
                
                while (true)
                {
                    DateTime start = DateTime.Now;

                    SampleScreen();

                    // Delay by the time taken to get samples (to halve average sample rate)
                    Thread.Sleep((DateTime.Now - start).Milliseconds);
                }
            }
            catch
            {
                // This is a prototype, forgive the lack of error handling (TODO: add error handling if this code develops beyond prototype stage)
            }
            finally
            {
                _controller.ShutDown();
            }
        }

        public static void SampleScreen()
        {
            foreach (ScreenSampleSpecification s in SampleSpecifications)
            {
                s.RgbDevice.Color = ScreenSample.FindAverage(s.SampleArea);
            }
        }
    }
}