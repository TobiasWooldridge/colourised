using System;
using System.IO.Ports;

namespace Colourised.Driver
{
    public class SerialController : Controller
    {
        private readonly SerialPort _port;

        public SerialController(SerialPort port)
        {
            _port = port;
            _port.Open();

            _port.DataReceived += (sender, args) => Console.Write("{0}", _port.ReadExisting());
        }

        protected override void Write(byte[] message)
        {
            try
            {
                _port.Write(message, 0, message.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
