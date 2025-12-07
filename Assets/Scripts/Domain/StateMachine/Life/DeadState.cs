using Domain.Components;
using Domain.Components.Interfaces;
using Domain.Events.Entity;

namespace Domain.StateMachine.Life
{
    public class DeadState : IEntityState<IHealthComponent>
    {
        public void Enter(IHealthComponent context)
        {
            context.Events.Emit(new DeathEvent());
        }

        public IEntityState<IHealthComponent> Update(IHealthComponent context, float deltaTime)
        {
            return this;
        }

        public void Exit(IHealthComponent context)
        {
            throw new System.NotImplementedException();
        }
    }
}