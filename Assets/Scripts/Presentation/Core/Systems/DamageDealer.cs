using Domain.Entities;

namespace Presentation.Core.Systems
{
    public class DamageDealer : EntityComponentView<Entity>
    {
        private Entity _context;
        
        public override void Initialize(Entity entity)
        {
            _context = entity;
        }

        public override void Cleanup()
        {
        }
    }
}