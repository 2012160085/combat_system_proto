using System;

namespace proto
{
    class CombatUnit
    {
      public void Attack(Action action){
          //CombatCallbacks.instance.OnAttack(action);;;
          AttackEffect(action);
          CombatCallbacks.instance.OnAttackLate(action);
      }
      public void AttackEffect(Action action){

      }
    }
}
