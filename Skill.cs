using System;

namespace proto
{
    class Skill
    {
        public virtual void enrollToCallback(){
            CombatCallbacks.instance.OnAttackLate += OnAttackLateEffect;
        }
        public virtual void OnAttackLateEffect(Action action){
            Console.WriteLine("base OnAttackLateEffect");
        }
    }
}
