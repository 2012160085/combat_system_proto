using System;
using System.Collections;

namespace proto
{
    
    interface IAimable
    {
        public ITargetable Target{
            get;
            set;
        }
        public ITargetable GetTarget(Hashtable acion);
        public void SetTarget(Hashtable action);
        public bool IsTargetExist();
    }
}
