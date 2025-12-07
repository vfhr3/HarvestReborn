using Domain.Components.Interfaces;
using Domain.Events;
using Domain.StateMachine;
using Domain.StateMachine.Life;

namespace Domain.Components.Common
{
    public class EntityHealthComponent : IEntityComponent, IHealthComponent
    {
        private readonly EntityStateMachine<IHealthComponent> _state;
        public IEventBus Events { get; }
        public EntityStateMachine<IHealthComponent> State => _state;
        public int Current { get; }
        public int Max { get; }
        public bool IsDead => Current <= 0;

        public EntityHealthComponent(IEventBus events)
        {
            Events = events;
            _state = new EntityStateMachine<IHealthComponent>(this, new AliveState());
        }

        public void Initialize()
        {
            
        }

        public void Update(float deltaTime)
        {
            _state.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            
        }

        public void Cleanup()
        {
            
        }
    }
}