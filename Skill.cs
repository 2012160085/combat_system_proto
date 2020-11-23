using System;
using System.Collections;
namespace proto
{
    class Skill
    {

        public CombatUnit owner;
        public string skillCode;
        public virtual void enrollToCallback(){
            CombatCallbacks.instance.OnAttackLate += OnAttackLateEffect;
        }
        public virtual void OnAttackLateEffect(Hashtable action){
            Console.WriteLine("base OnAttackLateEffect");
        }
        public virtual bool IsSkillReady(){
            return false;
        }

        public override string ToString()
        {
            return skillCode;
        }
    }
}
