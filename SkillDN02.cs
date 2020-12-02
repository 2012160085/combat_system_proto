using System.Collections.Generic;
using System;
using System.Collections;

namespace proto
{
    class SkillDN02 : Skill, IEffectable, IAimable, IDamagable, IDelayable, IReadiable, ICooldownable
    {
        private float baseReach;
        public float BaseReach { get => baseReach; set => baseReach = value; }

        private float reach;
        public float Reach { get => reach; set => reach = value; }
        public void SetReach(Hashtable action){
            reach = baseReach;
        }

        public SkillDN02()
        {
        }
        public SkillDN02(CombatUnit unit)
        {
            skillCode = "DN02";
            baseDelayTimeNeeded = 10;
            baseDelayTimePerTick = 1;
            baseReadyTimeNeeded = 10;
            baseReadyTimePerTick = 1;
            baseCooldownTimeNeeded = 10;
            baseCooldownTimePerTick = 1;
            baseReach = 3.5f;

            DelayTimeNeeded = baseDelayTimeNeeded;
            DelayTimePerTick = baseDelayTimePerTick;
            ReadyTimeNeeded = baseReadyTimeNeeded;
            ReadyTimePerTick = baseReadyTimePerTick;
            CooldownTimeNeeded = baseCooldownTimeNeeded;
            CooldownTimePerTick = baseCooldownTimePerTick;
            reach = baseReach;
        }
        ITargetable target;
        public ITargetable Target { get => target; set => target = value; }

        int damagePoint;
        public int DamagePoint { get => damagePoint; set => damagePoint = value; }

        int baseDamagePoint;
        public int BaseDamagePoint { get => baseDamagePoint; set => baseDamagePoint = value; }
        int delayTimeNeeded;
        public int DelayTimeNeeded { get => delayTimeNeeded; set => delayTimeNeeded = value; }

        int delayTime;
        public int DelayTime { get => delayTime; set => delayTime = value; }

        int delayTimePerTick;
        public int DelayTimePerTick { get => delayTimePerTick; set => delayTimePerTick = value; }

        bool isDelayExempted;
        public bool IsDelayExempted { get => isDelayExempted; set => isDelayExempted = value; }

        int readyTimeNeeded;
        public int ReadyTimeNeeded { get => readyTimeNeeded; set => readyTimeNeeded = value; }

        int readyTime;
        public int ReadyTime { get => readyTime; set => readyTime = value; }

        int readyTimePerTick;
        public int ReadyTimePerTick { get => readyTimePerTick; set => readyTimePerTick = value; }

        bool isReadyExempted;
        public bool IsReadyExempted { get => isReadyExempted; set => isReadyExempted = value; }

        int baseDelayTimeNeeded;
        public int BaseDelayTimeNeeded { get => baseDelayTimeNeeded; set => baseDelayTimeNeeded = value; }

        int baseDelayTimePerTick;
        public int BaseDelayTimePerTick { get => baseDelayTimePerTick; set => baseDelayTimePerTick = value; }

        int baseReadyTimeNeeded;
        public int BaseReadyTimeNeeded { get => baseReadyTimeNeeded; set => baseReadyTimeNeeded = value; }

        int baseReadyTimePerTick;
        public int BaseReadyTimePerTick { get => baseReadyTimePerTick; set => baseReadyTimePerTick = value; }

        int cooldownTimeNeeded;
        public int CooldownTimeNeeded { get => cooldownTimeNeeded; set => cooldownTimeNeeded = value; }

        int cooldownTime;
        public int CooldownTime { get => cooldownTime; set => cooldownTime = value; }

        int cooldownTimePerTick;
        public int CooldownTimePerTick { get => cooldownTimePerTick; set => cooldownTimePerTick = value; }

        int baseCooldownTimeNeeded;
        public int BaseCooldownTimeNeeded { get => baseCooldownTimeNeeded; set => baseCooldownTimeNeeded = value; }

        int baseCooldownTimePerTick;
        public int BaseCooldownTimePerTick { get => baseCooldownTimePerTick; set => baseCooldownTimePerTick = value; }

        public void Damage(Hashtable action)
        {
            CombatCallbacks.instance.RaiseOnDamage(action);
            CombatUnit targetUnit = (CombatUnit)action["target"];
            (targetUnit as IGetDamagable).GetDamage(action);
            CombatCallbacks.instance.RaiseOnDamageLate(action);
        }

        public void Delay(Hashtable action)
        {
            if (IsDelayCompleted())
            {
                throw new Exception("초과해서 딜레이 시도");
            }
            delayTime += delayTimePerTick;
        }

        public void Effect(Hashtable action)
        {
            Console.WriteLine(this.ToString() + " skill effects");
            action["target"] = this.target;
            action["damage"] = this.damagePoint;
            Damage(action);
        }
        public void SetDamagePoint(Hashtable action){
            this.DamagePoint = this.owner.CurDetStats.DistanceAttackPoint;
        }
        public bool IsTargetExist()
        {
            target = GetTarget(Action.SimpleAction(reach));
            return target != null;
        }

        public ITargetable GetTarget(Hashtable action)
        {
            
            UnitSelector filter = new UnitSelector();
            TeamUnitFilter teamUnitFilter = new TeamUnitFilter(1 - owner.team);
            DistanceUnitFilter distanceUnitFilter = new DistanceUnitFilter(0,
                (float)action["value"],
                owner.position,
                owner.direction == 1 ? DistanceUnitFilter.RangeType.righthand : DistanceUnitFilter.RangeType.lefthand);
            InterfaceUnitFilter interfaceUnitFilter = new InterfaceUnitFilter(typeof(ITargetable));
            filter.AddFilter(teamUnitFilter);
            filter.AddFilter(distanceUnitFilter);
            filter.AddFilter(interfaceUnitFilter);
            List<CombatUnit> selectedUnits = filter.Select(CombatUnit.AllUnits);
            if (selectedUnits.Count == 0)
            {
                Console.WriteLine(this + " target not found ");
                return null;
            }
            selectedUnits.Sort(new UnitComparer(UnitComparer.SortBy.distance));
            Console.WriteLine(this + " target found:" + selectedUnits[0]);
            return selectedUnits[0] as ITargetable;
        }

        public bool IsDelayCompleted()
        {
            return delayTime >= delayTimeNeeded;
        }

        public bool IsReadyCompleted()
        {
            return readyTime >= readyTimeNeeded;
        }

        public void Ready(Hashtable action)
        {
            readyTime += readyTimePerTick;
        }

        public void ResetReadyTime()
        {
            readyTime = 0;
        }

        public void SetDelayTime(Hashtable action)
        {
            delayTime = (int)action["value"];
        }

        public void SetDelayTimeNeeded(Hashtable action)
        {
            delayTimeNeeded = (int)action["value"];
        }

        public void SetDelayTimePerTick(Hashtable action)
        {
            delayTimePerTick = (int)action["value"];
        }

        public void SetReadyTimeNeeded()
        {
            throw new NotImplementedException();
        }

        public void SetReadyTime(Hashtable action)
        {
            throw new NotImplementedException();
        }

        public void SetCooldownTimeNeeded(Hashtable action)
        {
            throw new NotImplementedException();
        }

        public void SetCooldownTime(Hashtable action)
        {
            cooldownTime = (int)action["value"];
        }

        public void SetCooldownTimePerTick(Hashtable action)
        {
            throw new NotImplementedException();
        }

        public void Cooldown(Hashtable action)
        {
            SetCooldownTime(Action.SimpleAction(cooldownTime + cooldownTimePerTick));
        }

        public bool IsCooldownCompleted()
        {
            Console.WriteLine(this.ToString() + " Cooldown :" + cooldownTime + "/" + cooldownTimeNeeded);
            return cooldownTime >= cooldownTimeNeeded;
        }

        public void ResetCooldownTime()
        {
            throw new NotImplementedException();
        }

        public bool IsSkillReadyExceptCooldown()
        {
            SetTarget(Action.SimpleAction(0));
            return target != null && !IsCooldownCompleted();
        }

        public override bool IsSkillPrepared()
        {
            SetTarget(Action.SimpleAction(0));
            return IsCooldownCompleted() && target != null;
        }

        public void SetTarget(Hashtable action)
        {
            target = GetTarget(Action.SimpleAction(reach));
        }

        public void OnDelayCompleted(Hashtable action)
        {
            throw new NotImplementedException();
        }

        public void OnReadyCompleted(Hashtable action)
        {
            SetReadyTime(Action.SimpleAction(0));
        }

        public void OnCooldownCompleted(Hashtable action)
        {
            SetCooldownTime(Action.SimpleAction(0));
        }

    }

}
