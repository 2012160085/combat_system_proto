using System;
using System.Threading;

namespace proto
{
    class Program
    {
        static void Main(string[] args)
        {


            //피격시 GetDamage
            //타격시 Damage
            //체력변동시
            //넉백시
            //선봉일시
            //혼자남았을시
            //유닛이 죽을 시
            //스킬사용시 

            CombatCallbacks callbacks = new CombatCallbacks();

            CombatUnit unit1 = new CombatUnit();
            unit1.AddSkill(new SkillDN02(unit1));
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
            while (true)
            {

                foreach (CombatUnit unit in CombatUnit.AllUnits)
                {
                    unit.DoCombatTick();
                }
                Console.WriteLine("----Next Tick---");
                Thread.Sleep(1000);
            }
        }
        public void Start()
        {

        }
        public void Update()
        {

        }
    }
}
