using Domain.Models;

namespace Domain.StateMachine.Life
{
    public class AliveState : IEntityState<IHealth>
    {
        public void Enter(IHealth context)
        {
            
        }

        public IEntityState<IHealth> Update(IHealth context, float deltaTime)
        {
            if (context.IsDead) return new DeadState();
            return this;
        }

        public void Exit(IHealth context)
        {
            
        }
    }
}