using Abstractions.Entity;
using Events.Entity;

namespace Core.StateMachine
{
    public class MovingState : IEntityState
    {
        public void Enter(IEntityContext context)
        {
            context.Events.Emit(new MovementStartedEvent());
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            if (!context.Movement.IsMoving) return new IdleState();
            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}