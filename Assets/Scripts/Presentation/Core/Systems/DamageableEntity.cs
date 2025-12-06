using Domain.Entities;
using Domain.Events.Entity;

namespace Presentation.Core.Systems
{
    public class DamageableEntity : ContextDrivenComponent<Entity>
    {
        private Entity _context;

        public override void Initialize(Entity entity)
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