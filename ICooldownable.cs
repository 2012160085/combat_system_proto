using System;

namespace proto
{
    interface ICooldownable
    {
        public void Cooldown(CombatAction obj);
        public bool IsReady();
        public void ResetCooldown();
    }
}
