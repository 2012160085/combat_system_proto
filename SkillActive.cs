using System;

namespace proto
{
    class SkillActive : ICooldownable
    {


        public int coolTime;
        public int coolDown;
        public virtual void enrollToCallback(){
            CombatCallbacks.instance.OnAttackLate += OnAttackLateEffect;
        }
        public virtual void OnAttackLateEffect(CombatAction action){
            Console.WriteLine("base OnAttackLateEffect");
        }
        public bool IsReady(){
            
            return coolDown >= coolTime;
        }
        
        public void Cooldown(CombatAction action){
            CombatCallbacks.instance.OnCooldown(action);
        }
        public void ResetCooldown(){
            coolDown -= coolTime;
        }

    }
}
