using System;

namespace proto
{
    class SkillDN01 : SkillActive, IAimable
    {
        public float reach;

        public ITargetable Target { get => target; set => target= value; }
        ITargetable target;
        public bool existTarget()
        {
            return false;
        }

        public ITargetable GetTarget(CombatAction action)
        {
            return action.actor.GetCombatUnitsInDistance(reach,action.actor.team,action.actor.direction)[0] as ITargetable;
        }
    }
}
