using UnityEngine;

namespace Domain.Models
{
    public class MovementData
    {
        public Vector2 Direction { get; set; }
        public float Speed;
        public bool IsMoving => Direction.magnitude > 0.001;

        public void UpdateDirection(Vector2 direction)
        {
            Direction = direction;
        }
        
        public MovementData(float speed)
        {
            Speed = speed;
        }

    }
}