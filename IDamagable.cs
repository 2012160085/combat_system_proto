using System;
using System.Collections;
namespace proto
{
    interface IDamagable
    {
        public void Damage(Hashtable action);
        public int DamagePoint
        {
            get; set;
        }
    }
}
