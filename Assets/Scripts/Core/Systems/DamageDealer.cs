using Abstractions;
using Core.Entity;

namespace Core.Systems
{
    public class DamageDealer : ContextDrivenComponent<EntityContext>
    {
        private EntityContext _context;
        
        public override void Initialize(EntityContext context)
        {
            _context = context;
        }
    }
}