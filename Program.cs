using System;

namespace proto
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatCallbacks callbacks = new CombatCallbacks();
            CombatUnit unit = new CombatUnit();
            SkillNormalAttack skillNormalAttack = new SkillNormalAttack();
            
            skillNormalAttack.enrollToCallback();
            unit.Attack(new Action());
        
        }
    }
}
