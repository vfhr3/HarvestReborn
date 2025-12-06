using Domain.Models;

namespace Domain.StateMachine.Life
{
    public class DeadState : IEntityState<IHealth>
    {
        public void Enter(IHealth context)
        {
            
        }

        public IEntityState<IHealth> Update(IHealth context, float deltaTime)
        {
            return this;
        }

        public void Exit(IHealth context)
        {
            
        }
    }
}