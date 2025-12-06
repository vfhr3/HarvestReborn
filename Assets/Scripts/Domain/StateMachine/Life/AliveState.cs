using Domain.Entities;

namespace Domain.StateMachine.Life
{
    public class AliveState : IEntityState
    {
        public void Enter(IEntity context)
        {
            
        }

        public IEntityState Update(IEntity context, float deltaTime)
        {
            if (context.Health.IsDead) return new DeadState();
            return this;
        }

        public void Exit(IEntity context)
        {
            
        }
    }
}