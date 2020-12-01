using System;
using System.Collections;
namespace proto
{
    interface IDelayable
    {
        public int DelayTimeNeeded
        {
            get;
            set;
        }
        public int BaseDelayTimeNeeded
        {
            get;
            set;
        }
        public void SetDelayTimeNeeded(Hashtable action);
        public int DelayTime
        {
            get;
            set;
        }
        public void SetDelayTime(Hashtable action);
        public int DelayTimePerTick
        {
            get;
            set;
        }
        public int BaseDelayTimePerTick
        {
            get;
            set;
        }
        public void SetDelayTimePerTick(Hashtable action);

        public void OnDelayCompleted(Hashtable action);
        public void Delay(Hashtable action);
        public bool IsDelayExempted{
            get;set;
        }
        public bool IsDelayCompleted();
    }
}
