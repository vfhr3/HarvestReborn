using Domain.StateMachine;
using UnityEngine;

namespace Domain.Entities.Interfaces
{
    public interface IMoveable
    {
        Vector2 Position { get; }
        Vector2 Direction { get; }
        bool IsMoving { get; }
        float Speed { get; }

        void Move(Vector2 delta, float deltaTime);
        void UpdatePosition(Vector2 newPosition);
        void UpdateDirection(Vector2 newDirection);

    }

}