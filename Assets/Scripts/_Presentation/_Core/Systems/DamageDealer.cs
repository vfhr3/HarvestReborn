using Abstractions;
using Core.Entity;

namespace Core.Systems
{
    public class DamageDealer : ContextDrivenComponent<EntityContext>
    {
        private EntityContext _context;
        
        public override void Initialize(EntityContext playerContext)
        {
            _context = playerContext;
        }

        public override void Cleanup()
        {
            throw new System.NotImplementedException();
        }
    }
}