using Domain.Entities.Interfaces;
using Domain.Events.Entity;

namespace Presentation.Core.Systems
{
    public class DamageReceiver : EntityComponentView<IDamageable>
    {
        private IDamageable _damageable;
        
        public override void Initialize(IDamageable context)
        {
            _damageable = context;
        }

        public override void Cleanup()
        {
            
        }

        private void TakeDamage(int damage)
        {
            _damageable.TakeDamage(damage);
        }
    }
}