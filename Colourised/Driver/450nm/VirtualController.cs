using System;

namespace Colourised.Driver
{
    public class VirtualController : Controller
    {
        protected override void Write(byte[] message)
        {
            if (message[1] == (byte) Instruction.SetChannels)
            {
                Console.Write("[Set Channels] \t");

                var length = (UInt16) ((message[2] << 8) + message[3]);
                Console.Write("[{0} Channels]\t", length/4);


                for (int c = 0; c < length/4; c++)
                {
                    int i = c*4 + 4;

                    int channel = (message[i] << 8) + message[i + 1];
                    int value = (message[i + 2] << 8) + message[i + 3];

                    Console.Write("[C{0} V{1}]", channel, value);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(BitConverter.ToString(message));
            }
        }
    }
}