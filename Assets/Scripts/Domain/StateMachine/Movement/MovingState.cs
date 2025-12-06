using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Domain.StateMachine.Movement
{
    public class MovingState : IEntityState
    {
        private Vector2 _currentDirection;
        public void Enter(IEntity context)
        {
            Debug.Log($"Entered {GetType().Name}");
            context.Events.Emit(new DirectionChangedEvent(context.Direction));
            context.Events.Emit(new MovementStartedEvent());

            _currentDirection = context.Direction;
            context.IsMoving = true;
        }

        public IEntityState Update(IEntity context, float deltaTime)
        {
            if (context.Direction.sqrMagnitude == 0) return new IdleState();

            if (context.Direction != _currentDirection)
            {
                _currentDirection = context.Direction;
                context.Events.Emit(new DirectionChangedEvent(context.Direction));
            }

            var oldPosition = context.Position;
            var newPosition = context.Position + context.Direction * context.Speed * deltaTime;
            context.UpdatePosition(newPosition);
            context.Events.Emit(new PositionChangedEvent(oldPosition, newPosition));
            return this;
        }

        public void Exit(IEntity context)
        {
        }
    }
}
