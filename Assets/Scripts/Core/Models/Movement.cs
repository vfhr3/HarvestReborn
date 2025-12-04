using UnityEngine;

namespace Core.Models
{
    public class Movement
    {
        public float Speed;

        public Movement(float speed)
        {
            Speed = speed;
        }

        public Vector2 Direction { get; set; }
    }
}