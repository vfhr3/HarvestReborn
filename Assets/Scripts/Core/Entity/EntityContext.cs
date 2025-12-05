using System;
using Abstractions.Entity;
using Core.Models;
using Events;
using UnityEngine;


namespace Core.Entity
{
    [Serializable]
    public abstract class EntityContext : IEntityContext
    {
        public Vector2 Position { get; private set; }
        public Health Health { get; }
        public MovementData Movement { get; }
        public EventBus Events { get; }
        
        protected EntityContext(IEntityConfig<EntityContext> config)
        {
            Health = new Health(config.MaxHealth);
            Events = new EventBus();
            Movement = new MovementData(config.Speed);
        }
        
        public void Update(float deltaTime)
        {
            
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            
        }

        public void UpdatePosition(Vector2 position)
        {
            Position = position;
        }
    }
}