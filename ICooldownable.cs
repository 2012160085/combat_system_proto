using System;

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
        public void Cooldown(CooldownAction obj);
        public bool IsCool();
        public void ResetCooldown();

        public bool IsSkillReadyExceptCooldown();
    }
}
