using System;

namespace proto
{
    interface IAimable
    {
        public ITargetable Target{
            get;
            set;
        }
        public ITargetable GetTarget(CombatAction action);
        public bool existTarget();
    }
}
