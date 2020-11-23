using System;
using System.Collections;

namespace proto
{
    class CombatCallbacks
    {
        public static CombatCallbacks instance;
        public delegate void ActionDelegate(Hashtable action);
        public ActionDelegate OnAttack;
        public ActionDelegate OnAttackLate;
        public ActionDelegate OnCooldown;
        public ActionDelegate OnWalk;
        public CombatCallbacks(){
            instance = this;
        }
    }
}
