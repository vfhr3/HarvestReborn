using Events;
using UnityEngine;

namespace Abstractions.Entity
{
    public interface IEntityContext
    {
        public Vector2 Position { get; }
        public EventBus Events { get; }
        void Update(float deltaTime);
        void FixedUpdate(float fixedDeltaTime);
    }
}