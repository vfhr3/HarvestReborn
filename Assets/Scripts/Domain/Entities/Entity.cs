using System;
using Domain.Components;
using Domain.Container;
using Domain.Events;


namespace Domain.Entities
{
    public abstract class Entity : IEntity
    {
        private readonly EntityComponentContainer _container;
        public Guid Id { get; }
        public IEventBus Events { get; }
        
        protected Entity(IEventBus events, EntityComponentContainer container)
        {
            Id = Guid.NewGuid();
            Events = events;
            _container = container;
        }

        public T Get<T>() where T : IEntityComponent
        {
            return _container.Get<T>();
        }

        public virtual void Update(float deltaTime)
        {
            _container.Update(deltaTime);
        }

        public virtual void FixedUpdate(float fixedDeltaTime)
        {
            _container.FixedUpdate(fixedDeltaTime);
        }
    }
}