using Core.Entity;
using Events.Entity;

namespace Core.StateMachine
{
    public class IdleState : IEntityState
    {
        public void Enter(EntityContext context)
        {
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState Update(EntityContext context, float deltaTime)
        {
            if (context.IsMoving) return new MovingState();
            return this;
        }

        public void Exit(EntityContext context)
        {
        }
    }
}