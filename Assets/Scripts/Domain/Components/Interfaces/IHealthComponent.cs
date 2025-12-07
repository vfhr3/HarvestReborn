using Domain.Events;
using Domain.StateMachine;

namespace Domain.Components.Interfaces
{
    public interface IHealthComponent
    {
        public EntityStateMachine<IHealthComponent> State { get; }
        public IEventBus Events { get; }
        int Current { get; }
        int Max { get; }
        bool IsDead { get; }
    }
}