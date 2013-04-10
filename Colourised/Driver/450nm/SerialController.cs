using System;

using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourised.Hardware
{
    public class SerialController : Controller
    {
        private readonly SerialPort _port;

        public SerialController(SerialPort port) : base()
        {
            _port = port;
            _port.Open();

            _port.DataReceived += (sender, args) => Console.Write("{0}", _port.ReadExisting());
        }

        protected override void Write(byte[] message)
        {
            //Console.WriteLine();
            //Console.WriteLine(BitConverter.ToString(message));
            //Console.WriteLine();
            
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
