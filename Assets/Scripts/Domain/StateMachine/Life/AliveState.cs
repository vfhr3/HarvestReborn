using Domain.Components;
using Domain.Components.Interfaces;
using Domain.Events.Entity;

namespace Domain.StateMachine.Life
{
    public class AliveState : IEntityState<IHealthComponent>
    {
        public void Enter(IHealthComponent context)
        {
            context.Events.On<DamageTakenEvent>(TakeDamage);
        }


        public IEntityState<IHealthComponent> Update(IHealthComponent context, float deltaTime)
        {
            if (context.IsDead) return new DeadState();
            
            return this;
        }

        public void Exit(IHealthComponent context)
        {
            context.Events.Off<DamageTakenEvent>(TakeDamage);
        }
        
        private void TakeDamage(DamageTakenEvent e)
        {
            
        }
    }
}