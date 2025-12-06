using System;
using Domain.Events;


namespace Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; }
        public IEventBus Events { get; }
        
        protected Entity(IEventBus events)
        {
            Id = Guid.NewGuid();
            Events = events;
        }

        public virtual void Update(float deltaTime) { }

        public virtual void FixedUpdate(float fixedDeltaTime) { }
    }
}