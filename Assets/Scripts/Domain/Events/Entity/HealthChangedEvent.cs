namespace Domain.Events.Entity
{
    public class HealthChangedEvent : IEventData
    {
        public HealthChangedEvent(int difference, int oldHealth, int currentHealth)
        {
            Difference = difference;
            OldHealth = oldHealth;
            CurrentHealth = currentHealth;
        }

        public int Difference { get; set; }
        public int OldHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}