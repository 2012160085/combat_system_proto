using System.Collections.Generic;
using System;
namespace proto
{
    class CombatUnit : ITargetable
    {
      public static List<CombatUnit> AllUnits = new List<CombatUnit>();
  
      public enum AttackState{
        none,cast,ready,attack,delay
      }
      public string name;
      public float position;
      public int direction;
      public int team;
      public int hp;
      public int atk;
      public int spd;

      public AttackState attackState;
      public CombatUnit(){
        skillList = new List<Skill>();
        attackState = AttackState.none;
        AllUnits.Add(this);
      }
      public List<Skill> skillList;

      public void AddSkill(Skill skill){
        skillList.Add(skill);
        skill.enrollToCallback();
        skill.owner = this;
        skillList.Sort(new SkillComparer(SkillComparer.CompareMode.coolTime,SkillComparer.OrderBy.desc));
      }
      public void Attack(CombatAction action){
          //CombatCallbacks.instance.OnAttack(action);
          CombatCallbacks.instance.OnAttackLate(action);
      }
      public void DetermineState(){
        Skill skillPrepared = null;
        foreach(Skill skill in skillList){
          if(skill.IsSkillReady()){
            skillPrepared = skill;
            break;
          }
        }
        Skill skillPreparedExceptCooltime = null;
        if(skillPrepared == null){
          foreach(Skill skill in skillList){
            ICooldownable cSkill = skill as ICooldownable;
            if(cSkill!=null && cSkill.IsSkillReadyExceptCooldown()){
              skillPreparedExceptCooltime = skill;
              break;
            }
          }
        }


        //if there exist any usable skill
            //if skill is ready
                //use skill
            //else
                //idle
        //else 
            //walk
        
      }
      public void Cooldown(int spd){
        foreach(Skill skill in skillList){
          CooldownAction action = new CooldownAction();
          action.actor = this;
          action.skill = skill;
          action.cooldownValue = spd;
          ICooldownable activeSkill  = skill as ICooldownable;
          if (activeSkill != null){
            activeSkill.Cooldown(action);
          }
          CombatCallbacks.instance.OnCooldown(action);
        }
      }
      public void DoCombatTick(){
          
      }
      public override string ToString()
      {
          return this.name;
      }

      public bool existTarget()
      {
          throw new NotImplementedException();
      }
    }
}
