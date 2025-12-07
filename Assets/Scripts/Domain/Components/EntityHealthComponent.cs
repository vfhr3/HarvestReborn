using System;
using Domain.Events;
using Domain.StateMachine;
using Domain.StateMachine.Life;

namespace Domain.Components
{
    public class EntityHealthComponent : IEntityComponent, IHealthComponent
    {
        private EntityStateMachine<IHealthComponent> _state;
        public IEventBus Events { get; }
        public int Current { get; }
        public int Max { get; }
        public bool IsDead { get; }

        public EntityHealthComponent(IEventBus events)
        {
            Events = events;
            _state = new EntityStateMachine<IHealthComponent>(this, new AliveState());
        }
        
        public void ApplyDamage(int damage)
        {
            
        }
        
        public void ApplyHeal(int amount)
        {
            
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