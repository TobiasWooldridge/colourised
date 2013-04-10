using System;
using System.Threading;

namespace Colourised.Driver
{
    public class Channel
    {
        private readonly Mutex _mutex;

        public static int TransitionPeriod = 250;

        private UInt16 _startValue;
        private UInt16 _targetValue;

        private DateTime _valueChanged;

        private Boolean _stabilized = true;

        public Channel()
        {
            _mutex = new Mutex();

            _startValue = 0;
            _targetValue = 0;
            _valueChanged = DateTime.Now;
        }

        public UInt16 Current
        {
            get
            {
                _mutex.WaitOne();

                if (_stabilized)
                {
                    return _targetValue;
                }

                var transitionMillis = (DateTime.Now - _valueChanged).TotalMilliseconds;

                // Fraction of 1 representing how far we are from _startValue to _targetValue
                double transitioned = 0;
                if (transitionMillis > 0)
                {
                    transitioned = transitionMillis / TransitionPeriod;
                }

                if (transitioned >= 1)
                {
                    _stabilized = true;
                    return _targetValue;
                }

                return (UInt16)(_startValue + (_targetValue - _startValue) * transitioned);
            }
        }

        public UInt16 Target
        {
            get { return _targetValue; }
            set
            {
                _mutex.WaitOne();
                _startValue = Current;
                _valueChanged = DateTime.Now;
                _targetValue = value;
                _stabilized = false;
            }
        }

        public Byte CurrentByte
        {
            get { return (byte)(Current/16); }
        }

        public Byte TargetByte
        {
            get { return (byte)(Target / 16); }
            set { Target = (UInt16)(value * 16); }
        }
    }
}