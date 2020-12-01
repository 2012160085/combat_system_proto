using System;
using System.Collections;

namespace proto
{
    class CombatCallbacks
    {
        public static CombatCallbacks instance;
        public delegate void ActionDelegate(Hashtable action);
        public ActionDelegate OnAttack;
        public void RaiseOnAttack(Hashtable action){
            if (OnAttack != null)
                OnAttack(action);
        }
        public ActionDelegate OnAttackLate;
        public void RaiseOnAttackLate(Hashtable action){
            if (OnAttackLate != null)
                OnAttackLate(action);
        }
        public ActionDelegate OnCooldown;
        public void RaiseOnCooldown(Hashtable action){
            if (OnCooldown != null)
                OnCooldown(action);
        }
        public ActionDelegate OnDamage;
        public void RaiseOnDamage(Hashtable action){
            if (OnDamage != null)
                OnDamage(action);
        }
        public ActionDelegate OnDamageLate;
        public void RaiseOnDamageLate(Hashtable action){
            if (OnDamageLate != null)
                OnDamageLate(action);
        }
        public ActionDelegate OnGetDamage;
        public void RaiseOnGetDamage(Hashtable action){
            if (OnGetDamage != null)
                OnGetDamage(action);
        }
        public ActionDelegate OnGetDamageLate;
        public void RaiseOnGetDamageLate(Hashtable action){
            if (OnGetDamageLate != null)
                OnGetDamageLate(action);
        }
        public ActionDelegate OnWalk;
        public CombatCallbacks(){
            instance = this;
        }
    }
}
