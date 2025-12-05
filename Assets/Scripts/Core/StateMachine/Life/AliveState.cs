using Abstractions.Entity;

namespace Core.StateMachine.Life
{
    public class AliveState : IEntityState
    {
        public void Enter(IEntityContext context)
        {
            
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            if (context.Health.IsDead) return new DeadState();
            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}