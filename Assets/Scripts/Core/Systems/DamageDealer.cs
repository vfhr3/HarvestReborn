using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class DamageDealer : MonoBehaviour, IEntitySystem
    {
        private EntityContext _context;
        
        public void Initialize(EntityContext context)
        {
            _context = context;
        }
    }
}