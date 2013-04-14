using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Colourised.Driver
{
    public abstract class Controller
    {
        public enum Instruction : byte
        {
            Version = 0x00,
            Ping = 0x03,
            SetChannels = 0xBE,
            PowerDown = 0xFF
        }

        private const int MaxChildren = 1; // How many daisy chained TLC5940NT's -might- work
        private const int ChannelsPerChild = 16; // PWM channels provided by a TLC5940NT
        private const int MaxChannels = MaxChildren*ChannelsPerChild;
        private const int PingInterval = 500; // How many ms idle we'll send a ping after

        private const byte Preamble = 0xBA;

        private readonly Timer _worker;
        private DateTime _lastHeader = DateTime.Now;

        protected Controller()
        {
            Channels = new Channel[MaxChannels];
            for (int i = 0; i < Channels.Length; i++)
            {
                Channels[i] = new Channel();
            }
            ControllerValues = new UInt16[MaxChannels];

            _worker = new Timer();
            _worker.Elapsed += Work;
            _worker.Interval = 16;
        }


        public Channel[] Channels { get; private set; }
        public UInt16[] ControllerValues { get; private set; }

        private void Work(Object sender, ElapsedEventArgs eea)
        {
            Update();
        }

        public void Update()
        {
            List<byte> changedChannels = ChangedChannels();

            if (changedChannels.Any())
                SendCommand(Instruction.SetChannels, changedChannels);
            else if ((_lastHeader - DateTime.Now).TotalMilliseconds > PingInterval)
                SendCommand(Instruction.Ping, new List<byte>());
        }

        private IEnumerable<byte> EncodeIndexValue(UInt16 index, UInt16 value)
        {
            var encoded = new byte[3];

            encoded[0] = (byte) (index >> 4);
            encoded[1] = (byte) (((index & 0x0F) << 4) + (value >> 8));
            encoded[2] = (byte) (value);

            return encoded;
        }

        private List<byte> ChangedChannels()
        {
            var message = new List<byte>();

            for (UInt16 i = 0; i < Channels.Length; i++)
            {
                Channel c = Channels[i];
                ushort v = (ushort)(c.Current >> 4);

                // Don't resend if value hasn't changed
                if (v == ControllerValues[i]) continue;

                message.AddRange(EncodeIndexValue(i, v));

                ControllerValues[i] = v;
            }

            return message;
        }

        private void SendCommand(Instruction instruction, List<byte> body)
        {
            var packet = new List<byte>
                {
                    Preamble,
                    (byte) instruction,
                    (byte) (body.Count() >> 8),
                    (byte) body.Count()
                };

            packet.AddRange(body);

            byte checksum = packet.Aggregate<byte, byte>(0, (current, b) => (byte) (current ^ b));

            packet.Add(checksum);

            _lastHeader = DateTime.Now;
            Write(packet.ToArray());
        }

        protected abstract void Write(byte[] message);

        public void StartUpdates()
        {
            _worker.Enabled = true;
        }

        public void StopUpdates()
        {
            _worker.Enabled = false;
        }

        public void ShutDown()
        {
            StopUpdates();
            SendCommand(Instruction.PowerDown, new List<byte>());
        }
    }
}