using Abstractions.Entity;
using Events.Entity;
using UnityEngine;

namespace Core.StateMachine.Movement
{
    public class MovingState : IEntityState
    {
        private Vector2 _previousDirection;
        
        public void Enter(IEntityContext context)
        {
            Debug.Log($"Entered {GetType().Name}");
            _previousDirection = context.Direction;
            context.Events.Emit(new MovementStartedEvent());
            
            if (_previousDirection.sqrMagnitude > 0)
                context.Events.Emit(new DirectionChangedEvent(_previousDirection));
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            var currentDirection = context.Direction;

            if (currentDirection.sqrMagnitude > 0 && currentDirection != _previousDirection)
            {
                context.Events.Emit(new DirectionChangedEvent(currentDirection));
                _previousDirection = currentDirection;
            }

            if (currentDirection.sqrMagnitude == 0)
            {
                context.IsMoving = false;
                return new IdleState();
            }

            var oldPosition = context.Position;
            context.UpdatePosition(oldPosition + currentDirection.normalized * context.Speed * deltaTime);
            context.Events.Emit(new PositionChangedEvent(oldPosition, context.Position));

            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}