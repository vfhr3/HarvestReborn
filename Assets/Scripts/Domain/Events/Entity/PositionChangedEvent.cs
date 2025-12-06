using UnityEngine;

namespace Domain.Events.Entity
{
    public class PositionChangedEvent : IEventData
    {
        public Vector3 NewPosition;
        public Vector3 OldPosition;

        public PositionChangedEvent(Vector3 oldPosition, Vector3 newPosition)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
    }
}