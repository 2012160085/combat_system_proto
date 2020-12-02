using System.Collections;

namespace proto
{
    class Buff : ICooldownable
    {
        public int BaseCooldownTimeNeeded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int CooldownTimeNeeded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int CooldownTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int BaseCooldownTimePerTick { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int CooldownTimePerTick { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Cooldown(Hashtable action)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCooldownCompleted()
        {
            throw new System.NotImplementedException();
        }

        public bool IsSkillReadyExceptCooldown()
        {
            throw new System.NotImplementedException();
        }

        public void OnCooldownCompleted(Hashtable action)
        {
            throw new System.NotImplementedException();
        }

        public void ResetCooldownTime()
        {
            throw new System.NotImplementedException();
        }

        public void SetCooldownTime(Hashtable action)
        {
            throw new System.NotImplementedException();
        }

        public void SetCooldownTimeNeeded(Hashtable action)
        {
            throw new System.NotImplementedException();
        }

        public void SetCooldownTimePerTick(Hashtable action)
        {
            throw new System.NotImplementedException();
        }
    }
}