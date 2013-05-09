using System;
using System.Threading;

namespace Colourised.Driver
{
    public class SmoothBehavior
    {
        private readonly Mutex _mutex;

        private double _startValue;
        private double _targetValue;

        private DateTime _valueChanged;

        private Boolean _stabilized = true;

        // Transition period in miliseconds
        public int TransitionPeriod { get; set; }

        public SmoothBehavior()
        {
            _mutex = new Mutex();

            _startValue = 0;
            _targetValue = 0;
            _valueChanged = DateTime.Now;

            TransitionPeriod = 150;
        }

        public double DeviceValue
        {
            get
            {
                if (!_stabilized)
                {
                    _mutex.WaitOne();

                    var transitionMillis = (DateTime.Now - _valueChanged).TotalMilliseconds;

                    
                    double transitionedProgress = 0;
                    if (transitionMillis > 0)
                        transitionedProgress = transitionMillis/TransitionPeriod;

                    if (transitionedProgress >= 1)
                        _stabilized = true;
                    else
                        return _startValue + (_targetValue - _startValue) * transitionedProgress;
                }


                return _targetValue;
            }
        }

        public byte DeviceValueByte
        {
            get { return (byte)(DeviceValue * Byte.MaxValue); }
        }

        public double Target
        {
            get { return _targetValue; }
            set
            {
                _mutex.WaitOne();
                _startValue = DeviceValue;
                _valueChanged = DateTime.Now;
                _targetValue = value;
                _stabilized = false;
            }
        }


        public byte TargetByte
        {
            get { return (byte)(Target * Byte.MaxValue); }
            set { Target = (double)value / Byte.MaxValue; }
        }
    }
}
