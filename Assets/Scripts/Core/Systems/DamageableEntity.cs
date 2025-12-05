using Abstractions;
using Abstractions.Common;
using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class DamageableEntity : ContextDrivenComponent<IDamageable>
    {
        private IDamageable _context;

        public override void Initialize(IDamageable context)
        {
            _context = context;
        }
        public void TakeDamage(int damage)
        {
            _context.TakeDamage(damage);
        }
    }
}