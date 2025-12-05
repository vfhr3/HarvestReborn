using System;
using Core.Entity;
using Entities.Player.Data;
using Events.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class EntityMovement : MonoBehaviour
    {
        private EntityContext _context;
        private Rigidbody2D _rb;

        public void Initialize(Rigidbody2D rb, EntityContext context)
        {
            _rb = rb;
            _context = context;
            _context.Events.On<PositionChangedEvent>(Move);
        }

        private void Move(PositionChangedEvent eventData)
        {
            _rb.MovePosition(eventData.NewPosition);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Vector3 from = _rb.position;
            Vector3 to = from + (Vector3)_context.Movement.Direction;
            
            Gizmos.DrawLine(from, to);
        }
    }
}