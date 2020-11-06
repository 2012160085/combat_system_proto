using System;

namespace proto
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatCallbacks callbacks = new CombatCallbacks();
            CombatUnit unit = new CombatUnit();
            SkillDN01 skillNormalAttack = new SkillDN01();
            
            unit.AddSkill(skillNormalAttack);
            unit.Attack(new CombatAction());
        
        }
        public void Start(){

        }
        public void Update(){

        }
    }
}
