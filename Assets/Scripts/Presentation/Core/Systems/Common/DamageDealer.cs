using Domain.Entities;

namespace Presentation.Core.Systems
{
    public class DamageDealer : IEntityComponentView<Entity>
    {
        private Entity _context;
        
        public void Initialize(Entity entity)
        {
            _context = entity;
        }

        public void Cleanup()
        {
        }
    }
}