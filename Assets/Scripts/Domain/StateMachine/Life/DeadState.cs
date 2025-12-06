using Domain.Entities;
using Domain.Events.Entity;

namespace Domain.StateMachine.Life
{
    public class DeadState : IEntityState
    {
        public void Enter(IEntity context)
        {
            context.Events.Emit(new DeathEvent());
        }

        public IEntityState Update(IEntity context, float deltaTime)
        {
            return this;
        }

        public void Exit(IEntity context)
        {
            
        }
    }
}