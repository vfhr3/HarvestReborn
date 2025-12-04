using Abstractions;
using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class DamageableEntity : MonoBehaviour, IDamageable
    {
        private EntityContext _context;

        public bool IsDead => _context.IsDead;

        public void TakeDamage(int damage)
        {
            _context.TakeDamage(damage);
        }

        public void Init(EntityContext context)
        {
            _context = context;
        }
    }
}