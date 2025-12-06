namespace Domain.Events.Entity
{
    public class GracePeriodStartedEvent : IEventData
    {
        public GracePeriodStartedEvent(float duration)
        {
            Duration = duration;
        }

        public float Duration { get; set; }
    }
}