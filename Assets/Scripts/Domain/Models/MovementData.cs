using Domain.Entities.Interfaces;
using Domain.Events;
using Domain.Events.Entity;
using UnityEngine;

namespace Domain.Models
{
    public class EntityMovement : IMoveable
    {
        private readonly IEventBus _events;
        public EntityMovement(float speed, IEventBus events)
        {
            Speed = speed;
            _events = events;
        }
        public Vector2 Position { get; private set; }
        public Vector2 Direction { get; private set; }
        public bool IsMoving { get; private set; }
        public float Speed { get; }

        public void Move(Vector2 delta, float deltaTIme)
        {
            var oldPosition = Position;
            Position += delta * Speed * deltaTIme;
            IsMoving = delta.sqrMagnitude > 0;
            
            _events.Emit(new PositionChangedEvent(oldPosition, Position));

            if (IsMoving)
            {
                _events.Emit(new MovementStartedEvent());
            }
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            Position = newPosition;
            
        }

        public void UpdateDirection(Vector2 newDirection)
        {
            Direction = newDirection;
            _events.Emit(new DirectionChangedEvent(Direction));
        }
    }
}