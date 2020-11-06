using System.Collections.Generic;
using System;
namespace proto
{
    class CombatUnit
    {
      public static List<CombatUnit> AllUnits = new List<CombatUnit>();
  
      public List<CombatUnit> GetCombatUnitsInDistance(float distance,int team, int direction){
        List<CombatUnit> units = new List<CombatUnit>();
        foreach(CombatUnit unit in AllUnits){
          if(MathF.Abs(position-unit.position) > distance)
            continue;
          if(team >= 0 && team != unit.team)
            continue;
          if(direction >= 0 && direction != unit.direction )
            continue;
          units.Add(unit);
        }
        return units;
      }
      public enum AttackState{
        none,cast,ready,attack,delay
      }
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
      }
      public void Attack(CombatAction action){
          //CombatCallbacks.instance.OnAttack(action);
          CombatCallbacks.instance.OnAttackLate(action);
      }
      public void DetermineState(){
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
    }
}
