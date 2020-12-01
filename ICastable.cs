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
        public int BaseCastTimeNeeded
        {
            get;
            set;
        }
        public void SetCastTimeNeeded(Hashtable action);
        public int CastTime
        {
            get;
            set;
        }
        public void SetCastTime(Hashtable action);
        public int CastTimePerTick
        {
            get;
            set;
        }
        public int BaseCastTimePerTick
        {
            get;
            set;
        }
        public void SetCastTimePerTick(Hashtable action);
        public void OnCastCompleted(Hashtable action);
        public void Cast(Hashtable action);
        public bool IsCastCompleted();
        public void ResetCastTime();
        public bool IsCastExempted
        {
            get; set;
        }
    }
}
