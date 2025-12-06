using _Domain._StateMachine;
using Abstractions.Entity;
using Events.Entity;

namespace Core.StateMachine.Life
{
    public class DeadState : IEntityState
    {
        public void Enter(IEntityContext context)
        {
            context.Events.Emit(new DeathEvent());
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}