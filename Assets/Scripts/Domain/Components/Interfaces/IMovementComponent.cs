using Domain.Events;
using UnityEngine;

namespace Domain.Components.Interfaces
{
    public interface IMovementComponent
    {
        public IEventBus Events { get; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; }
        public bool IsMoving { get; }
        public float Speed { get; }
    }
}