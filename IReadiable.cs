using System;
using System.Collections;
namespace proto
{
    interface IReadiable
    {   
        public int BaseReadyTimeNeeded{
            get;set;
        }
        public int ReadyTimeNeeded{
            get;
            set;
        }
        public void SetReadyTimeNeeded();
        public int ReadyTime{
            get;
            set;
        }
        public void SetReadyTime();
        public int ReadyTimePerTick{
            get;
            set;
        }
        public int BaseReadyTimePerTick{
            get;
            set;
        }
        public void Ready(Hashtable action);
        public bool IsReadyCompleted();
        public void ResetReadyTime();
        public bool IsReadyExempted{
            get;set;
        }
    }
}
