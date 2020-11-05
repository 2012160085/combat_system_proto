using System.Collections.Generic;

namespace proto
{
    class CombatUnit
    {
      public enum AttackState{
        none,cast,ready,attack,delay
      }
      public int hp;
      public int atk;
      public int spd;

      public AttackState attackState;
      public CombatUnit(){
        skillList = new List<Skill>();
        attackState = AttackState.none;
      }
      public List<Skill> skillList;

      public void AddSkill(Skill skill){
        skillList.Add(skill);
        skill.enrollToCallback();
      }
      public void Attack(CombatAction action){
          //CombatCallbacks.instance.OnAttack(action);
          CombatCallbacks.instance.OnAttackLate(action);
      }
      public void Cooldown(int spd){
        foreach(Skill skill in skillList){
          CooldownAction action = new CooldownAction();
          action.actor = this;
          action.skill = skill;
          action.cooldownValue = spd;
          ICooldownable activeSkill  = skill as ICooldownable;
          if (skill != null){
            
          }
          CombatCallbacks.instance.OnCooldown(action);
        }
      }
      public void DoCombatTick(){
          
      }
    }
}
