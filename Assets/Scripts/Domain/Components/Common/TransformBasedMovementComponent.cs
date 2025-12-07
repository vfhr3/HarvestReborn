using Domain.Components.Interfaces;
using Domain.Events;
using Domain.StateMachine;
using Domain.StateMachine.Movement;
using UnityEngine;

namespace Domain.Components.Common
{
    public class TransformBasedMovementComponent : IMovementComponent, IEntityComponent
    {
        private readonly EntityStateMachine<IMovementComponent> _state;
        private readonly ITransformProvider _transform;
        public IEventBus Events { get; }

        public Vector2 Position
        {
            get => _transform.Position;
            set => _transform.Position = value;
        }
        
        public Vector2 Direction { get; }
        public bool IsMoving => Direction.sqrMagnitude > 0;
        public float Speed { get; }

        public TransformBasedMovementComponent(
            IEventBus events,
            ITransformProvider transform,
            float speed)
        {
            Events = events;
            _transform = transform;
            Speed = speed;
            Direction = Vector2.zero;

            _state = new EntityStateMachine<IMovementComponent>(this, new IdleState());
        }
        
        
        public void Initialize() { }

        public void Update(float deltaTime) { }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _state.Update(fixedDeltaTime);
        }

        public void Cleanup()
        {
            
        }

    }
}