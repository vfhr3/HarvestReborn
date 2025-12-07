using Domain.Components;
using Domain.Components.Interfaces;
using Domain.Events.Entity;
using UnityEngine;

namespace Domain.StateMachine.Movement
{
    public class MovingState: IEntityState<IMovementComponent>
    {
        private Vector2 _currentDirection;
        public void Enter(IMovementComponent context)
        {
            _currentDirection = context.Direction;
            context.Events.Emit(new DirectionChangedEvent(_currentDirection));
            context.Events.Emit(new MovementStartedEvent());
        }

        public IEntityState<IMovementComponent> Update(IMovementComponent context, float deltaTime)
        {
            if (!context.IsMoving) return new IdleState();

            var oldPos = context.Position;
            var deltaPos = deltaTime * context.Speed * context.Direction;
            var newPos = context.Position + deltaPos;
            context.Position = newPos;
            context.Events.Emit(new PositionChangedEvent(oldPos, context.Position));
            
            return this;
        }

        public void Exit(IMovementComponent context)
        {
            
        }
    }
}
