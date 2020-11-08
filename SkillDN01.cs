using System.Collections.Generic;
using System;
namespace proto
{
    class SkillDN01 : SkillActive, IAimable
    {
        public float reach = 2.3f;

        public ITargetable Target { get => target; set => target= value; }
        ITargetable target;
        public bool existTarget()
        {
            return false;
        }

        public ITargetable GetTarget(CombatAction action)
        {
            UnitSelector filter = new UnitSelector();
            TeamUnitFilter teamUnitFilter = new TeamUnitFilter(1-action.actor.team);
            DistanceUnitFilter distanceUnitFilter = new DistanceUnitFilter(0,
                reach,
                action.actor.position,
                action.actor.direction == 1 ? DistanceUnitFilter.RangeType.righthand : DistanceUnitFilter.RangeType.lefthand);
            InterfaceUnitFilter interfaceUnitFilter = new InterfaceUnitFilter(typeof(ITargetable));
            filter.AddFilter(teamUnitFilter);
            filter.AddFilter(distanceUnitFilter);
            filter.AddFilter(interfaceUnitFilter);
            List<CombatUnit> selectedUnits = filter.Select(CombatUnit.AllUnits);
            if( selectedUnits.Count == 0){
                Console.WriteLine(action + " target not found ");
                return null;
            }
            selectedUnits.Sort(new UnitComparer(UnitComparer.SortBy.distance));
            Console.WriteLine(action + " target found:" + selectedUnits[0]);
            return selectedUnits[0] as ITargetable;
        }
    }
}
