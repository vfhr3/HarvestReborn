using System;
using System.Collections.Generic;
using Domain.Components;

namespace Domain.Container
{
    public class EntityComponentContainer : IContainer<IEntityComponent>
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new();

        public void Add<T>(T instance) where T : IEntityComponent
        {
            _components.Add(typeof(T), instance);
        }

        public T Get<T>() where T : IEntityComponent
        {
            return (T)_components[typeof(T)];
        }

        public void Update(float deltaTime)
        {
            foreach (var entityComponent in _components)
            {
                entityComponent.Value.Update(deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (var entityComponent in _components)
            {
                entityComponent.Value.FixedUpdate(fixedDeltaTime);
            }
        }
    }
}