using Domain.Events;

namespace Domain.Components
{
    public interface IHealthComponent
    {
        public IEventBus Events { get; }
        int Current { get; }
        int Max { get; }
        bool IsDead { get; }

        void ApplyDamage(int damage);
        void ApplyHeal(int amount);
    }
}