using System.Collections.Generic;

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
            Unitfilter filter = new Unitfilter();
            List<CombatUnit> units = filter.filter(CombatUnit.AllUnits);
            units.Sort(filter.Compare);
            return units[0] as ITargetable;
        }
    }
}
