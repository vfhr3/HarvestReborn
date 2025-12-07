using Domain.Components.Interfaces;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems
{
    public class DamageReceiver : MonoBehaviour, IEntityComponentView<IHealthComponent>
    {
        private IHealthComponent _context;
        public void Initialize(IHealthComponent context)
        {
            _context = context;
        }

        public void Cleanup()
        {
            
        }

        private void TakeDamage()
        {
            _context.Events.Emit();
        }
        
        
    }
}