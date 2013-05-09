using System;
using System.Drawing;
using Colourised.Driver;

namespace Colourised.Service
{
    class ScreenSampleSpecification
    {
        private RgbDevice _rgbDevice;
        public RgbDevice RgbDevice
        {
            get { return _rgbDevice; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("No RgbDevice given");
                }

                _rgbDevice = value;
            }
        }

        private Rectangle _sampleArea;
        public Rectangle SampleArea
        {
            get { return _sampleArea; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("No sample area given");
                }

                _sampleArea = value;
            }
        }


        private String _name;
        public String Name
        {
            get
            {
                return _name ?? "Unnamed Sample Specification";
            }
            set
            {
                _name = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public ScreenSampleSpecification(RgbDevice rgbDevice, Rectangle sampleArea)
        {
            _rgbDevice = rgbDevice;
            _sampleArea = sampleArea;
        }

        public ScreenSampleSpecification(RgbDevice rgbDevice, Rectangle sampleArea, String name) : this(rgbDevice, sampleArea)
        {
            _name = name;
        }
    }
}