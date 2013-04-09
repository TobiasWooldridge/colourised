using System;
using System.IO.Ports;
using SplashPixel.Hardware;

namespace SplashPixelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = new SerialPort("COM3", 115200);

            var controller = new SerialController(port);
            //var controller = new VirtualController();

            Console.ReadLine();

            controller.ShutDown();

            for (int i = 0; i < 16; i++)
            {
                controller.Channels[i].Target = 0;
            }

            controller.Update();
            Console.ReadLine();

            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("Channel {0}", i);
                controller.Channels[i].Target = 4095;

                controller.Update();
                Console.ReadLine();

                controller.Channels[i].Target = 0;
            }

            Console.ReadLine();
        }
    }
}
