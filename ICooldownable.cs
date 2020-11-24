using System;
using System.Collections;
namespace proto
{
    interface ICooldownable
    {
        public int CooldownTimeNeeded
        {
            get;
            set;
        }
        public int CooldownTime
        {
            get;
            set;
        }
        public int CooldownTimePerTick
        {
            get;
            set;
        }
        public void Cooldown(Hashtable action);
        public bool IsCooldownCompleted();
        public void ResetCooldownTime();
        public bool IsSkillReadyExceptCooldown();
    }
}
