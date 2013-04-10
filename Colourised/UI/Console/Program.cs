using System;
using System.IO.Ports;
using Colourised.Hardware;

namespace Colourised.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = new SerialPort("COM3", 115200);

            var controller = new SerialController(port);
            //var controller = new VirtualController();

            System.Console.ReadLine();

            controller.ShutDown();

            for (var i = 0; i < 16; i++)
            {
                controller.Channels[i].Target = 0;
            }

            controller.Update();
            System.Console.ReadLine();

            for (var i = 0; i < 16; i++)
            {
                System.Console.WriteLine("Channel {0}", i);
                controller.Channels[i].Target = 4095;

                controller.Update();
                System.Console.ReadLine();

                controller.Channels[i].Target = 0;
            }

            System.Console.ReadLine();
        }
    }
}
