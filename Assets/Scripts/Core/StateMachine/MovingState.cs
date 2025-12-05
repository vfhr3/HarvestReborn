using Abstractions;
using Abstractions.Common;
using Core.Entity;
using Events.Entity;

namespace Core.StateMachine
{
    public class MovingState : IEntityState<IMoveable>
    {
        public void Enter(IMoveable context)
        {
            context.Events.Emit(new MovementStartedEvent());
        }

        public IEntityState<IMoveable> Update(IMoveable context, float deltaTime)
        {
            if (!context.IsMoving) return new IdleState();
            return this;
        }

        public void Exit(IMoveable context)
        {
            
        }
    }
}