using System.Drawing;
using System.Threading;
using Colourised.Util;

namespace Colourised.Driver.RgbDeviceBehavior
{
    public class ScreenSampleRgbBehavior : RgbBehavior
    {
        // todo: make all instances of behavior share sampling thread
        private readonly Thread _sampleThread;

        public ScreenSampleRgbBehavior()
        {
            _sampleThread = new Thread(Sample);
            _sampleThread.Start();

            SampleArea = new Rectangle(0, 0, 1, 1);
        }

        protected void Sample()
        {
            // todo: implement a way to stop this thread
            while (true)
            {
                if (HasChannels)
                {
                    try
                    {
                        Color = ScreenSample.FindAverage(SampleArea);
                    }
                    catch
                    {
                        // This catches every exception. That is bad.
                        // todo: remove this try/catch
                    }
                }

                Thread.Sleep(250);
            }
        }

        public Color Color
        {
            get
            {
                return HasChannels ? Color.FromArgb(R.TargetByte, G.TargetByte, B.TargetByte) : Color.Black;
            }
            set
            {
                if (!HasChannels) return;

                R.TargetByte = value.R;
                G.TargetByte = value.G;
                B.TargetByte = value.B;
            }
        }

        public Rectangle SampleArea
        {
            get;
            set;
        }
    }
}
