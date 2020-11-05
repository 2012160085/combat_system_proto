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
            
            unit.AddSkill(skillNormalAttack);
            unit.Attack(new CombatAction());
        
        }
        public void Start(){

        }
        public void Update(){

        }
    }
}
