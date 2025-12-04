namespace Events.Entity
{
    public class DirectionChangedEvent : IEventData
    {
        public DirectionChangedEvent(bool isFacingRight)
        {
            IsFacingRight = isFacingRight;
        }

        public bool IsFacingRight { get; }
    }
}