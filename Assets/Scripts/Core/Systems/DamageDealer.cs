using Abstractions;
using Core.Entity;
using UnityEngine;

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