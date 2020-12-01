using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace proto
{
    class UnitSelector 
    {
        public UnitSelector(){
            filters = new List<IUnitFiltable>();
        } 
        private List<IUnitFiltable> filters;
        public void AddFilter(IUnitFiltable unitFilter){
            filters.Add(unitFilter);
        }
        public List<CombatUnit> Select(List<CombatUnit> units){
            List<CombatUnit> result = new List<CombatUnit>();
            foreach(CombatUnit unit in units){
                bool filtered = false;
                foreach(IUnitFiltable filter in filters){
                    if (!filter.filter(unit)){
                        filtered = true;
                        break;
                    }       
                }
                if(!filtered)
                    result.Add(unit);
            }
            return result;
        }
        
    }

    interface IUnitFiltable{
        public bool filter(CombatUnit unit);
    }

    class TeamUnitFilter : IUnitFiltable{
        public int team;
        public TeamUnitFilter(int team){
            this.team = team;
        }
        public bool filter(CombatUnit unit)
        {
            return unit.team == team;
        }
    }
    class PositionUnitFilter : IUnitFiltable{
        public float minPosition;
        public float maxPosition;

        public PositionUnitFilter(float minPosition,float maxPosition, float pivotPos){
            this.minPosition = minPosition;
            this.maxPosition = maxPosition;
        }
        public bool filter(CombatUnit unit)
        {
            return unit.position <= maxPosition && minPosition <= unit.position;
        }
    }
    class DistanceUnitFilter : IUnitFiltable{
        public float minDistance;
        public float maxDistance;
        public float pivotPos;
        public enum RangeType{
            righthand, lefthand, none
        }
        public RangeType rangeType = RangeType.none;
        public DistanceUnitFilter(float minDistance, float maxDistance,float pivotPos, RangeType rangeType){
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
            this.pivotPos = pivotPos;
            this.rangeType = rangeType;
        }
        public bool filter(CombatUnit unit)
        {
            Console.WriteLine(rangeType + "/" + unit.position + "/" + minDistance + "/" + maxDistance);
            switch(rangeType){
                case RangeType.none:
                    return MathF.Abs(unit.position-pivotPos) <= maxDistance && minDistance <= MathF.Abs(unit.position-pivotPos) ;
                case RangeType.lefthand:
                    return  (pivotPos-unit.position) <= maxDistance && minDistance <= (pivotPos-unit.position);
                case RangeType.righthand:
                    return  -(pivotPos-unit.position) <= maxDistance && minDistance <= -(pivotPos-unit.position);
            }
            return MathF.Abs(unit.position-pivotPos) <= maxDistance && minDistance <= MathF.Abs(unit.position-pivotPos) ;
        }
    }
    class InterfaceUnitFilter : IUnitFiltable{
        Type interfaceType;
        public InterfaceUnitFilter(Type interfaceType){
            this.interfaceType = interfaceType;
        }

        public bool filter(CombatUnit unit)
        {
            return interfaceType.IsAssignableFrom(unit.GetType());
        }
    }
    class UnitComparer : IComparer<CombatUnit>
    {
        public UnitComparer(SortBy sortBy){
            this.sortBy = sortBy;
        }
        public enum SortBy{
            postion, distance
        }
        public SortBy sortBy = SortBy.postion;
        public float pivotPosition;
        public int Compare([AllowNull] CombatUnit x, [AllowNull] CombatUnit y)
        {
            switch(sortBy){
                case SortBy.postion:
                    return x.position.CompareTo(y.position);
                case SortBy.distance:
                    return MathF.Abs(x.position-pivotPosition).CompareTo(MathF.Abs(y.position-pivotPosition));
            }
            return x.position.CompareTo(y.position);
        }
    }
}
