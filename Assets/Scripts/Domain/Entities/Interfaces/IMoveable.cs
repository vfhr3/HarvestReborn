using UnityEngine;

namespace Domain.Entities.Interfaces
{
    public interface IMoveable
    {
        public bool IsMoving { get; set; }
        public Entity Context { get; set; }
        void Move(Vector2 direction);
    }
}