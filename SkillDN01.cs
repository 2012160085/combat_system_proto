using System.Collections.Generic;
using System;
namespace proto
{
    class SkillDN01 : SkillActive, IAimable
    {

        public SkillDN01(){
            this.skillCode = "[SillDN01]";
        }
        public override bool IsSkillReady()
        {
            return base.IsSkillReady() && GetTarget() != null;
        }
        public override bool IsSkillReadyExceptCooldown(){
            return GetTarget() != null;
        }
        public float reach = 3f;

        public ITargetable Target { get => target; set => target= value; }
        ITargetable target;
        public bool existTarget()
        {
            return false;
        }

        public ITargetable GetTarget()
        {
            UnitSelector filter = new UnitSelector();
            TeamUnitFilter teamUnitFilter = new TeamUnitFilter(1-owner.team);
            DistanceUnitFilter distanceUnitFilter = new DistanceUnitFilter(0,
                reach,
                owner.position,
                owner.direction == 1 ? DistanceUnitFilter.RangeType.righthand : DistanceUnitFilter.RangeType.lefthand);
            InterfaceUnitFilter interfaceUnitFilter = new InterfaceUnitFilter(typeof(ITargetable));
            filter.AddFilter(teamUnitFilter);
            filter.AddFilter(distanceUnitFilter);
            filter.AddFilter(interfaceUnitFilter);
            List<CombatUnit> selectedUnits = filter.Select(CombatUnit.AllUnits);
            if( selectedUnits.Count == 0){
                Console.WriteLine(this + " target not found ");
                return null;
            }
            selectedUnits.Sort(new UnitComparer(UnitComparer.SortBy.distance));
            Console.WriteLine(this + " target found:" + selectedUnits[0]);
            return selectedUnits[0] as ITargetable;
        }
    }
}
