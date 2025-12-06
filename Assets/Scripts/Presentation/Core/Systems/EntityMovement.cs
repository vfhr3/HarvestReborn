using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems
{
    public class EntityMovement : ContextDrivenComponent<Entity>
    {
        private Entity _entity;
        private Rigidbody2D _rb;

        public override void Initialize(Entity entity)
        {
            _entity = entity;
            _entity.Events.On<PositionChangedEvent>(Move);
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void Cleanup()
        {
            _entity.Events.Off<PositionChangedEvent>(Move);
        }

        private void Move(PositionChangedEvent eventData)
        {
            _rb.MovePosition(eventData.NewPosition);
        }
    }
}