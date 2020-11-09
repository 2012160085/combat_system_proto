using System;

namespace proto
{
    interface IAimable
    {
        public ITargetable Target{
            get;
            set;
        }
        public ITargetable GetTarget();
        public bool existTarget();
    }
}
