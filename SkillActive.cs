using System;

namespace proto
{
    class SkillActive : Skill, ICooldownable
    {

        public override bool IsSkillReady(){
            return IsCool();
        }
        public virtual bool IsSkillReadyExceptCooldown(){
            return true;
        }
        int ICooldownable.CoolTime { get => coolTime; set => coolTime = value; }
        int ICooldownable.CoolDown { get => coolDown; set => coolDown = value; }

        int coolDown;
        int coolTime;
        public bool IsCool(){
            return coolDown >= coolTime;
        }
        
        public void Cooldown(CooldownAction action){
            if(IsCool())
                throw new Exception(this + " 초과해서 쿨다운 시도");
            CombatCallbacks.instance.OnCooldown(action);
            coolDown += action.cooldownValue;
        }
        public void ResetCooldown(){
            coolDown -= coolTime;
        }

    }
}
