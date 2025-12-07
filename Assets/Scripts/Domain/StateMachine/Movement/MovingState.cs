using Domain.Components;
using Domain.Events.Entity;

namespace Domain.StateMachine.Movement
{
    public class MovingState: IEntityState<IMovementComponent>
    {
        public void Enter(IMovementComponent context)
        {
            context.Events.Emit(new MovementStartedEvent());
        }

        public IEntityState<IMovementComponent> Update(IMovementComponent context, float deltaTime)
        {
            if (!context.IsMoving) return new IdleState();

            var deltaPos = deltaTime * context.Speed * context.Direction;
            context.Move(deltaPos);
            
            return this;
        }

        public void Exit(IMovementComponent context)
        {
            
        }
    }
}
