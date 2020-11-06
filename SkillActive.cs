using System;

namespace proto
{
    class SkillActive : Skill, ICooldownable
    {
        int ICooldownable.CoolTime { get => coolTime; set => coolTime = value; }
        int ICooldownable.CoolDown { get => coolDown; set => coolDown = value; }

        int coolDown;
        int coolTime;
        public bool IsReady(){
            return coolDown >= coolTime;
        }
        
        public void Cooldown(CooldownAction action){
            CombatCallbacks.instance.OnCooldown(action);
            coolDown += action.cooldownValue;
        }
        public void ResetCooldown(){
            coolDown -= coolTime;
        }

    }
}
