using Domain.Events;
using Domain.Events.Entity;
using Domain.StateMachine;
using Domain.StateMachine.Movement;
using UnityEngine;

namespace Domain.Components
{
    public class EntityMovementComponent : IMovementComponent, IEntityComponent
    {
        public IEventBus Events { get; }
        private readonly EntityStateMachine<IMovementComponent> _state;
        
        public Vector2 Position { get; private set; }
        public Vector2 Direction { get; private set; }
        public bool IsMoving => Direction.sqrMagnitude > 0;
        public float Speed { get; private set; }
        public void Move(Vector2 delta)
        {
            var oldPos = Position;
            Position += delta;
            Events.Emit(new PositionChangedEvent(oldPos, Position));
        }

        public void UpdateDirection(Vector2 direction)
        {
            Direction = direction;
            Events.Emit(new DirectionChangedEvent(direction));
        }

        public EntityMovementComponent(IEventBus events)
        {
            Events = events;
            _state = new EntityStateMachine<IMovementComponent>(this, new IdleState());
            Initialize();
        }
        
        public void Initialize()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _state.Update(fixedDeltaTime);
        }

        public void Cleanup()
        {
            
        }
    }

    public interface IMovementComponent
    {
        public IEventBus Events { get; }
        public Vector2 Position { get; }
        public Vector2 Direction { get; }
        public bool IsMoving { get; }
        public float Speed { get; }

        public void Move(Vector2 delta);
        public void UpdateDirection(Vector2 direction);
    }
}