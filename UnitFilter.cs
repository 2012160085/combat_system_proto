using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace proto
{
    class Unitfilter : IComparer<CombatUnit>
    {
        public Unitfilter(){
            team = -1;
            minPosition = float.MinValue;
            maxPosition = float.MaxValue;
            direction = 0;
        }
        public List<CombatUnit> filter(List<CombatUnit> units){
            List<CombatUnit> result = new List<CombatUnit>();
            foreach(CombatUnit unit in units){
                if(team >=0 && unit.team != team)
                    continue;
                if(direction != 0 && unit.direction != direction)
                    continue;
                if(minPosition >= unit.position)
                    continue;
                if(maxPosition <= unit.position)
                    continue;
                result.Add(unit);
            }
            return result;
        }

        public enum SortBy{
            postion, distance
        }
        public SortBy sortBy = SortBy.postion;
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

        public int team;
        public float minPosition;
        public float maxPosition;
        public float direction;
        public float pivotPosition;
        
    }
}
