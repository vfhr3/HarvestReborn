using Abstractions;
using Abstractions.Common;
using Core.Entity;
using Events.Entity;

namespace Core.Systems
{
    public class DamageableEntity : ContextDrivenComponent<EntityContext>
    {
        private EntityContext _context;

        public override void Initialize(EntityContext playerContext)
        {
            _context.Events.On<DamageTakenEvent>(TakeDamage);
        }

        public override void Cleanup()
        {
            _context.Events.Off<DamageTakenEvent>(TakeDamage);
        }

        private void TakeDamage(DamageTakenEvent e)
        {
            _context.Health.ApplyDamage(e.Damage);
        }

    }
}