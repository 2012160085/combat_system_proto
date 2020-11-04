using System;

namespace proto
{
    class CombatCallbacks
    {
        public static CombatCallbacks instance;
        public delegate void ActionDelegate(Action action);
        public ActionDelegate OnAttack;
        public ActionDelegate OnAttackLate;
        public CombatCallbacks(){
            instance = this;
        }
    }
}
