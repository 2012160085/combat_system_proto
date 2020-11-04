using System;

namespace proto
{
    class SkillNormalAttack : Skill
    {
        public override void enrollToCallback()
        {
            base.enrollToCallback();
        }
        public override void OnAttackLateEffect(Action action)
        {
            base.OnAttackLateEffect(action);
            Console.WriteLine("override OnAttackLateEffect");
        }
    }
}
