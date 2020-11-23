using System;
using System.Collections;

namespace proto
{
    
    interface ICastable
    {
        public void Cast(Hashtable action);
        public int CastTimePerTick{
            get;set;
        }
        public int CastTimeNeeded{
            get;set;
        }
        public bool CastReady();
    }
}
