using System;

namespace proto
{
    class CombatCallbacks
    {
        public static CombatCallbacks instance;
        public delegate void ActionDelegate(CombatAction action);
        public ActionDelegate OnAttack;
        public ActionDelegate OnAttackLate;
        public ActionDelegate OnCooldown;
        public CombatCallbacks(){
            instance = this;
        }
    }
}
