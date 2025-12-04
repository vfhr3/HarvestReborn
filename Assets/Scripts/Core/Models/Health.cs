using System;

namespace Core.Models
{
    [Serializable]
    public class Health
    {
        public Health(int maxHealth)
        {
            Max = maxHealth;
            Current = maxHealth;
        }

        public int Current { get; private set; }

        public int Max { get; }

        public bool IsDead => Current <= 0;

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            Current = Math.Max(0, Current - damage);
        }
    }
}