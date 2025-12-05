using Abstractions;
using Core.Entity;
using Events.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class EntityMovement : ContextDrivenComponent<EntityContext>
    {
        private EntityContext _context;
        private Rigidbody2D _rb;

        public override void Initialize(EntityContext context)
        {
            context.Events.On<PositionChangedEvent>(Move);
        }
        private void Move(PositionChangedEvent eventData)
        {
            _rb.MovePosition(eventData.NewPosition);
        }
    }
}