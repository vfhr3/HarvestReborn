using Abstractions.Entity;
using Events.Entity;

namespace Core.StateMachine
{
    public class IdleState : IEntityState
    {
        public void Enter(IEntityContext context)
        {
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            if (context.Movement.IsMoving) return new MovingState();
            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}