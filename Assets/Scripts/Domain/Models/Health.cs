using System;
using Domain.Events;
using Domain.Events.Entity;

namespace Domain.Models
{
    [Serializable]
    public class Health : IHealth
    {
        public Health(int max, IEventBus events)
        {
            Max = max;
            Events = events;
            Current = max;
        }

        public int Current { get; private set; }
        public int Max { get; }
        public bool IsDead => Current <= 0;
        public IEventBus Events { get; }
        
        public void ApplyDamage(int damage)
        {
            if (IsDead) return;

            var oldHealth = Current;
            Current = Math.Clamp(Current - damage, 0, Max);
            if (oldHealth != Current)
                Events.Emit(new HealthChangedEvent(Math.Abs(Current - oldHealth), Current, oldHealth, Max));
            
            Events.Emit(new DamageTakenEvent(damage, oldHealth, Current, IsDead));
        }

        public void ApplyHeal(int amount)
        {
            if (IsDead) return;

            var oldHealth = Current;
            Current = Math.Clamp(Current + amount, 0, Max);
            if (oldHealth != Current)
                Events.Emit(new HealthChangedEvent(Math.Abs(Current - oldHealth), Current, oldHealth, Max));
        }
    }
}