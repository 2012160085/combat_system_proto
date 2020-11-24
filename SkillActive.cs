using System;
using System.Collections;
namespace proto
{
    class SkillActive : Skill, ICooldownable
    {

        public override bool IsSkillReady()
        {
            return IsCooldownCompleted();
        }
        public virtual void SkillEffect(Hashtable action){
            
        }
        public virtual bool IsSkillReadyExceptCooldown()
        {
            return true;
        }
        int ICooldownable.CooldownTimeNeeded { get => cooldownTimeNeeded; set => cooldownTimeNeeded = value; }
        int ICooldownable.CooldownTime { get => cooldownTime; set => cooldownTime = value; }
        int ICooldownable.CooldownTimePerTick { get => cooldownTimePerTick; set => cooldownTimePerTick = value; }

        int cooldownTime;
        int cooldownTimeNeeded;
        int cooldownTimePerTick;
        public bool IsCooldownCompleted()
        {
            return cooldownTime >= cooldownTimeNeeded;
        }
        public void Cooldown(Hashtable action)
        {
            if (IsCooldownCompleted())
                throw new Exception(this + " 초과해서 쿨다운 시도");
            CombatCallbacks.instance.OnCooldown(action);
            cooldownTime += cooldownTimePerTick;
        }
        public void ResetCooldownTime()
        {
            cooldownTime -= cooldownTimeNeeded;
        }

    }
}
