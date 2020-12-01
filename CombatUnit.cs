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
        };
        public enum MoveState
        {
            idle, walk, knockback
        };
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
            AttackEffect(action);
            CombatCallbacks.instance.OnAttackLate(action);
        }
        public void AttackEffect(Hashtable action){
            
        }
        private void SetAttackState(AttackState state)
        {
            Console.WriteLine(this.ToString() + " AttackState[" + attackState.ToString() + "->" + state.ToString() +"]");
            attackState = state;
        }
        private void SetMoveState(MoveState state)
        {
            moveState = state;
        }
        public void CompleteCasting(){

        }
        public void DetermineState()
        {
            Console.WriteLine(this.ToString() +" DetermineState()");
            switch (attackState)
            {
                case AttackState.none:
                    Console.WriteLine(this.ToString() +" Attack State None");
                    CaseAttackStateNone();
                    break;
                case AttackState.cast:
                    Console.WriteLine(this.ToString() +" Attack State Cast");
                    CaseAttackStateCast();
                    break;
                case AttackState.ready:
                    Console.WriteLine(this.ToString() +" Attack State Ready");
                    CaseAttackStateReady();
                    break;
                case AttackState.attack:
                    Console.WriteLine(this.ToString() +" Attack State Attack");
                    CaseAttackStateReady();
                    break;
            }
        }
        private void CaseAttackStateNone()
        {
            Skill skillPrepared = null;
            foreach (Skill skill in skillList)
            {
                if (skill.IsSkillPrepared())
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
                skillFocused = skillPrepared;
                moveState = MoveState.idle;
                ICastable cSkill = skillPrepared as ICastable;
                IReadiable rSkill = skillPrepared as IReadiable;
                if (cSkill != null && !cSkill.IsCastExempted)
                {
                    SetAttackState(AttackState.cast);
                }
                else if (rSkill != null && !rSkill.IsReadyExempted)
                {
                    SetAttackState(AttackState.ready);
                }
                else
                {
                    SetAttackState(AttackState.attack);
                }
            }
            else if (skillPreparedExceptCooltime != null)
            {
                SetMoveState(MoveState.idle);
                SetAttackState(AttackState.none);
            }
            else
            {
                SetMoveState(MoveState.walk);
                SetAttackState(AttackState.none);
            }
        }
        private void CaseAttackStateCast()
        {
            ICastable skill = skillFocused as ICastable;
            Hashtable action = new Hashtable();
            if (skill.IsCastCompleted() || skill.IsCastExempted)
            {
                SetAttackState(AttackState.ready);
            }
            else
            {
                skill.Cast(action);
            }
        }

        private void CaseAttackStateReady()
        {
            IReadiable skill = skillFocused as IReadiable;
            Hashtable action = new Hashtable();
            if (skill.IsReadyCompleted() || skill.IsReadyExempted)
            {
                SetAttackState(AttackState.ready);
            }
            else
            {
                skill.Ready(action);
            }
        }
        private void CaseAttackStateAttack()
        {
            IEffectable skill = skillFocused as IEffectable;
            Hashtable action = new Hashtable();
            skill.Effect(action);
            SetAttackState(AttackState.delay);
        }
        private void CaseAttackStateDelay()
        {
            IDelayable skill = skillFocused as IDelayable;
            Hashtable action = new Hashtable();
            if (skill.IsDelayCompleted() || skill.IsDelayExempted)
            {
                SetAttackState(AttackState.none);
            }
            else
            {
                skill.Delay(action);
            }
        }
        public void DoCombatTick()
        {
            foreach(Skill skill in skillList){
                ICooldownable cSkill = skill as ICooldownable;
                if (cSkill != null && !cSkill.IsCooldownCompleted()){
                    cSkill.Cooldown(Action.SimpleAction(0));
                }
            }
            DetermineState();
        }
        public override string ToString()
        {
            return "["+this.name+"]";
        }

        public bool IsTargeted()
        {
            throw new NotImplementedException();
        }
    }
}
