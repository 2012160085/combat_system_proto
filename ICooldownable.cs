using System;
using System.Collections;
namespace proto
{
    interface ICooldownable
    {
        public int BaseCooldownTimeNeeded
        {
            get;
            set;
        }
        public int CooldownTimeNeeded
        {
            get;
            set;
        }
        public void SetCooldownTimeNeeded(Hashtable action);
        public int CooldownTime
        {
            get;
            set;
        }
        public void SetCooldownTime(Hashtable action);
        public int BaseCooldownTimePerTick
        {
            get;
            set;
        }
        public int CooldownTimePerTick
        {
            get;
            set;
        }
        public void SetCooldownTimePerTick(Hashtable action);
        public void OnCooldownCompleted(Hashtable action);
        public void Cooldown(Hashtable action);
        public bool IsCooldownCompleted();
        public void ResetCooldownTime();
        public bool IsSkillReadyExceptCooldown();
    }
}
