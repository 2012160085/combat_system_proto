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

            CombatUnit unit2 = new CombatUnit();
            unit2.direction = -1;
            unit2.position = 1.5f;
            unit2.team = 1;
            unit2.name = "unit2";

            CombatUnit unit3 = new CombatUnit();
            unit3.direction = -1;
            unit3.position = 1.4f;
            unit3.team = 1;
            unit3.name = "unit3";


            unit1.DetermineState();
            
        }
        public void Start(){

        }
        public void Update(){

        }
    }
}
