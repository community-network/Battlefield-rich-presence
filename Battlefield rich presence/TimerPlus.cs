using System;
using System.Timers;

namespace BattlefieldRichPresence
{
    internal class TimerPlus : Timer
    {
        private DateTime _mDueTime;

        public TimerPlus() => Elapsed += ElapsedAction;

        protected new void Dispose()
        {
            Elapsed -= ElapsedAction;
            base.Dispose();
        }

        public double TimeLeft => (_mDueTime - DateTime.Now).TotalMilliseconds;
        public new void Start()
        {
            _mDueTime = DateTime.Now.AddMilliseconds(Interval);
            base.Start();
        }

        private void ElapsedAction(object sender, ElapsedEventArgs e)
        {
            if (AutoReset)
                _mDueTime = DateTime.Now.AddMilliseconds(Interval);
        }
    }
}
