using Abstractions.Entity;
using Events;
using UnityEngine;


namespace Core.Entity
{
    public abstract class EntityContext : IEntityContext
    {
        public Vector2 Position { get; }
        public EventBus Events { get; }

        protected EntityContext(int a)
        {
            
        }
        
        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}