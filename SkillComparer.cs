using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace proto
{
    class SkillComparer : IComparer<Skill>
    {
        public enum CompareMode
        {
            coolTime
        }
        public CompareMode compareMode;
        public enum OrderBy
        {
            asc, desc
        }
        public OrderBy orderBy;
        public SkillComparer(){
            orderBy = OrderBy.asc;
            compareMode = CompareMode.coolTime;
        }
        public SkillComparer(CompareMode compareMode, OrderBy orderBy){
            orderBy = OrderBy.asc;
            compareMode = CompareMode.coolTime;
        }
        public int Compare([AllowNull] Skill x, [AllowNull] Skill y)
        {
            float coolX = x as ICooldownable == null ? float.MaxValue : (x as ICooldownable).CoolTime;
            float coolY = y as ICooldownable == null ? float.MaxValue : (y as ICooldownable).CoolTime;
            int val = 0;
            if(coolX < coolY)
                val = -1;
            if(coolX > coolY)
                val = 1;
            return orderBy == OrderBy.desc ? val * -1 : val;
        }
    }
}