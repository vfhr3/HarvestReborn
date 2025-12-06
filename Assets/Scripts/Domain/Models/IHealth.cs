using Domain.Events;

namespace Domain.Models
{
    public interface IHealth
    {
        int Current { get; }
        int Max { get; }
        bool IsDead { get; }
        IEventBus Events { get; }

        void ApplyDamage(int damage);
        void ApplyHeal(int amount);
    }
}