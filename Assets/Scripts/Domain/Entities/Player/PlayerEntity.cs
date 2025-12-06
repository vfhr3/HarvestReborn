using Domain.Entities.Interfaces;
using Domain.Events;
using Domain.Models;

namespace Domain.Entities.Player
{
    public class PlayerEntity : Entity, IDamageable
    {
        private IHealth _health;
        public PlayerEntity(IEventBus events, IHealth health) : base(events)
        {
            _health = health;
        }

        public override void FixedUpdate(float fixedDeltaTime)
        {
            
        }

        public void TakeDamage(int damage)
        {
            _health.ApplyDamage(damage);
        }
    }
}