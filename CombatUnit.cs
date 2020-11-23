using System.Collections.Generic;
using System;
using System.Collections;

namespace proto
{
    class CombatUnit : ITargetable
    {
        public static List<CombatUnit> AllUnits = new List<CombatUnit>();
        public Skill skillFocused;
        public enum AttackState
        {
            none, cast, ready, attack, delay
        }
        public enum MoveState
        {
            idle, walk, knockback
        }
        public string name;
        public float position;
        public int direction;
        public int team;
        public int hp;
        public int atk;
        public int spd;

        public AttackState attackState;
        public MoveState moveState;
        public CombatUnit()
        {
            skillList = new List<Skill>();
            attackState = AttackState.none;
            AllUnits.Add(this);
        }
        public List<Skill> skillList;

        public void AddSkill(Skill skill)
        {
            skillList.Add(skill);
            skill.enrollToCallback();
            skill.owner = this;
            skillList.Sort(new SkillComparer(SkillComparer.CompareMode.coolTime, SkillComparer.OrderBy.desc));
        }
        public void Attack(Hashtable action)
        {
            //CombatCallbacks.instance.OnAttack(action);
            CombatCallbacks.instance.OnAttackLate(action);
        }
        public void DetermineState()
        {
          switch (attackState){
            case AttackState.none:
              CaseAttackStateNone();
              break;
            case AttackState.cast:
              CaseAttackStateCast();
              break;
          }


        }
        private void CaseAttackStateNone(){
          Skill skillPrepared = null;
                foreach (Skill skill in skillList)
                {
                    if (skill.IsSkillReady())
                    {
                        skillPrepared = skill;
                        break;
                    }
                }
                Skill skillPreparedExceptCooltime = null;
                if (skillPrepared == null)
                {
                    foreach (Skill skill in skillList)
                    {
                        ICooldownable cSkill = skill as ICooldownable;
                        if (cSkill != null && cSkill.IsSkillReadyExceptCooldown())
                        {
                            skillPreparedExceptCooltime = skill;
                            break;
                        }
                    }
                }

                //if there exist any usable skill
                if (skillPrepared != null)
                {
                    moveState = MoveState.idle;
                    attackState = skillPrepared.getStateOnUse();
                }
                else if (skillPreparedExceptCooltime != null)
                {
                    moveState = MoveState.idle;
                    attackState = AttackState.none;
                }
                else
                {
                    moveState = MoveState.walk;
                    attackState = AttackState.none;
                }
        }
        private void CaseAttackStateCast(){
          
        }
        public void Cooldown(int spd)
        {
            foreach (Skill skill in skillList)
            {
                Hashtable action = new Hashtable();
                action[Code.insActor] = this;
                action[Code.insSkill] = skill;
                action[Code.iCooldownValue] = spd;
                ICooldownable activeSkill = skill as ICooldownable;
                if (activeSkill != null)
                {
                    activeSkill.Cooldown(action);
                }
                CombatCallbacks.instance.OnCooldown(action);
            }
        }
        public void DoCombatTick()
        {

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
