using Core.Models;
using Core.StateMachine;
using Events;
using UnityEngine;

namespace Abstractions.Entity
{
    public interface IEntityContext
    {
        bool IsMoving { get; set; }
        float Speed { get; }
        Vector2 Direction { get; }
        Vector2 Position { get; }
        IEventBus Events { get; }
        Health Health { get; }
        EntityStateMachine MovementState { get; }
        EntityStateMachine LifeState { get; }
        
        void Update(float deltaTime);
        void FixedUpdate(float fixedDeltaTime);

        void UpdatePosition(Vector2 position);

    }
}