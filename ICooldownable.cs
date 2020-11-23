using System;
using System.Collections;
namespace proto
{
    interface ICooldownable
    {   
        public int CoolTime{
            get;
            set;
        }
        public int CoolDown{
            get;
            set;
        }
        public void Cooldown(Hashtable action);
        public bool IsCool();
        public void ResetCooldown();

        public bool IsSkillReadyExceptCooldown();
    }
}
