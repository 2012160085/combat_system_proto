using System;
using System.Collections;
namespace proto
{
    class DetStats
    {
        public DetStats(CharStats charStats){
            AttackPoint = charStats.Dex + charStats.Str;
            DistanceAttackPoint = charStats.Dex*2;
            DefensePoint = 0;
            MagicAttackPoint = charStats.Knw;
            MagicDefensePoint = charStats.Knw;
            EffectHit = charStats.Knw + charStats.Luk;
            EffectDodge = charStats.Knw + charStats.Luk;
            AttackSpeed = charStats.Dex;
            MoveSpeed = charStats.Dex + charStats.Str;
            CriticalChance = charStats.Dex + charStats.Luk;
            DodgeChance = charStats.Dex;
            Knockback = charStats.Str;
            KnokbackRegist = charStats.Hp + charStats.Str;
        }

        int attackPoint;
        int defensePoint;
        int distanceAttackPoint;
        int magicAttackPoint;
        int magicDefensePoint;
        int effectHit;
        int effectDodge;
        int attackSpeed;
        int moveSpeed;
        int criticalChance;
        int dodgeChance;
        int knockback;
        int knokbackRegist;

        public int AttackPoint { get => attackPoint; set => attackPoint = value; }
        public int DefensePoint { get => defensePoint; set => defensePoint = value; }
        public int DistanceAttackPoint { get => attackPoint; set => attackPoint = value; }
        public int MagicAttackPoint { get => magicAttackPoint; set => magicAttackPoint = value; }
        public int MagicDefensePoint { get => magicDefensePoint; set => magicDefensePoint = value; }
        public int EffectHit { get => effectHit; set => effectHit = value; }
        public int EffectDodge { get => effectDodge; set => effectDodge = value; }
        public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
        public int MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public int CriticalChance { get => criticalChance; set => criticalChance = value; }
        public int DodgeChance { get => dodgeChance; set => dodgeChance = value; }
        public int Knockback { get => knockback; set => knockback = value; }
        public int KnokbackRegist { get => knokbackRegist; set => knokbackRegist = value; }
        
        

        public override string ToString()
        {
            return "" ;
        }
    }
}
