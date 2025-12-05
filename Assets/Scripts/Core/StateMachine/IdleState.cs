using Abstractions.Common;
using Events.Entity;

namespace Core.StateMachine
{
    public class IdleState : IEntityState<IMoveable>
    {
        public void Enter(IMoveable context)
        {
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState<IMoveable> Update(IMoveable context, float deltaTime)
        {
            if (context.IsMoving) return new MovingState();
            return this;
        }

        public void Exit(IMoveable context)
        {
            
        }
    }
}