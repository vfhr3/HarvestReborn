using Domain.Components;
using Domain.Events.Entity;

namespace Domain.StateMachine.Movement
{
    public class IdleState : IEntityState<IMovementComponent>
    {
        public void Enter(IMovementComponent context)
        {
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState<IMovementComponent> Update(IMovementComponent context, float deltaTime)
        {
            if (context.IsMoving) return new MovingState();

            return this;
        }

        public void Exit(IMovementComponent context)
        {
            
        }
    }
}