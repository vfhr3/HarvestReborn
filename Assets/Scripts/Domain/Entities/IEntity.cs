using Domain.Models;
using Domain.StateMachine;
using Infrastructure.Events;
using UnityEngine;

namespace Domain.Entities
{
    public interface IEntity
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