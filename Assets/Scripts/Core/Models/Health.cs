using System;

namespace Core.Models
{
    [Serializable]
    public class Health : IHealthSystem
    {

        public Health(int maxHealth)
        {
            Max = maxHealth;
            Current = maxHealth;
        }
        public int Current { get; private set; }
        public int Max { get; private set; }
        public bool IsDead => Current <= 0;
        public void ApplyDamage(int damage)
        {
            damage = Math.Max(0, damage);
            Current = Math.Clamp(Current - damage, 0, Max);
        }

        public void Heal(int amount)
        {
            amount = Math.Max(0, amount);
            Current = Math.Clamp(Current + amount, 0, Max);
        }
    }

    public interface IHealthSystem
    {
        bool IsDead { get; }
        int Current { get; }
        int Max { get; }
        void ApplyDamage(int damage);
        void Heal(int amount);
    }
}