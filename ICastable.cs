using System;
using System.Collections;
namespace proto
{
    interface ICastable
    {
        public int CastTimeNeeded
        {
            get;
            set;
        }
        public int CastTime
        {
            get;
            set;
        }
        public int CastTimePerTick
        {
            get;
            set;
        }
        public void Cast(Hashtable action);
        public bool IsCastCompleted();
        public void ResetCastTime();

        public bool IsCastExempted
        {
            get; set;
        }
    }
}
