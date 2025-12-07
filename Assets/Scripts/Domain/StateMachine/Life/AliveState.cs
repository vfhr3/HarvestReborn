using Domain.Components;

namespace Domain.StateMachine.Life
{
    public class AliveState : IEntityState<IHealthComponent>
    {
        public void Enter(IHealthComponent context)
        {
            
        }

        public IEntityState<IHealthComponent> Update(IHealthComponent context, float deltaTime)
        {
            if (context.IsDead) return new DeadState();
            return this;
        }

        public void Exit(IHealthComponent context)
        {
            
        }
    }
}