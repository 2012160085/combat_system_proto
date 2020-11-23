using System;
using System.Collections;
namespace proto
{
    class SkillNormalAttack : Skill
    {
        public override void enrollToCallback()
        {
            base.enrollToCallback();
        }
        public override void OnAttackLateEffect(Hashtable action)
        {
            base.OnAttackLateEffect(action);
            Console.WriteLine("override OnAttackLateEffect");
        }
    }
}
