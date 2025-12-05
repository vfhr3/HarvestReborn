using Core.Entity;
using Core.Models;
using Events;
using UnityEngine;

namespace Abstractions.Entity
{
    public interface IEntityContext
    {
        Vector2 Position { get; }
        EventBus Events { get; }
        Health Health { get; }
        MovementData Movement { get; }
        void Update(float deltaTime);
        void FixedUpdate(float fixedDeltaTime);

        void UpdatePosition(Vector2 position);

    }
}