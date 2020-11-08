using System;

namespace proto
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatCallbacks callbacks = new CombatCallbacks();

            CombatUnit unit1 = new CombatUnit();
            unit1.AddSkill(new SkillDN01());
            unit1.name = "unit1";
            unit1.direction = 1;
            unit1.position = -1;
            unit1.team = 0;
            unit1.Attack(new CombatAction());

            CombatUnit unit2 = new CombatUnit();
            unit2.direction = -1;
            unit2.position = 1;
            unit2.team = 1;
            unit2.Attack(new CombatAction());
            unit2.name = "unit2";

            CombatUnit unit3 = new CombatUnit();
            unit3.direction = -1;
            unit3.position = 0.9f;
            unit3.team = 1;
            unit3.Attack(new CombatAction());
            unit3.name = "unit3";


            unit1.DetermineState();
            
        }
        public void Start(){

        }
        public void Update(){

        }
    }
}
