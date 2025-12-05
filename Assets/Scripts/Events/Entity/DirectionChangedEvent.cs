using UnityEngine;

namespace Events.Entity
{
    public class DirectionChangedEvent : IEventData
    {
        public DirectionChangedEvent(Vector2 direction)
        {
            Direction = direction;
        }

        public Vector2 Direction { get; }
    }
}