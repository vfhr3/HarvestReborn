using Core.Entity;
using Events.Entity;

namespace Core.StateMachine
{
    public class MovingState : IEntityState
    {
        public void Enter(EntityContext context)
        {
            context.Events.Emit(new MovementStartedEvent());
        }

        public IEntityState Update(EntityContext context, float deltaTime)
        {
            if (!context.IsMoving) return new IdleState();
            return this;
        }

        public void Exit(EntityContext context)
        {
        }
    }
}