using System;
using System.Collections;
namespace proto
{
    interface IReadiable
    {   
        public int ReadyTimeNeeded{
            get;
            set;
        }
        public int ReadyTime{
            get;
            set;
        }
        public int ReadyTimePerTick{
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
