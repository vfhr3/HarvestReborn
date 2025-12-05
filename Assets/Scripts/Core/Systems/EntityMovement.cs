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

        public override void Initialize(EntityContext playerContext)
        {
            _context = playerContext;
            _context.Events.On<PositionChangedEvent>(Move);
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void Cleanup()
        {
            _context.Events.Off<PositionChangedEvent>(Move);
        }

        private void Move(PositionChangedEvent eventData)
        {
            _rb.MovePosition(eventData.NewPosition);
        }
    }
}