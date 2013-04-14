using System;
using System.Threading;

namespace Colourised.Driver.ChannelBehavior
{
    class SmoothBehavior : TargetableBehavior
    {
        private readonly Mutex _mutex;

        private UInt16 _startValue;
        private UInt16 _targetValue;

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

        public override ushort DeviceValue
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
        public override ushort Target
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
    }
}
