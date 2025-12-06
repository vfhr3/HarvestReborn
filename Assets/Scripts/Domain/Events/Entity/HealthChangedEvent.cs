namespace Domain.Events.Entity
{
    public class HealthChangedEvent : IEventData
    {
        public HealthChangedEvent(int difference, int currentHealth, int oldHealth, int maxHealth)
        {
            Difference = difference;
            OldHealth = oldHealth;
            CurrentHealth = currentHealth;
            Percent = (float)currentHealth / maxHealth;
            MaxHealth = maxHealth;
        }

        public int Difference { get; }
        public int OldHealth { get; }
        public int CurrentHealth { get; set; }
        public float Percent { get; }
        public int MaxHealth { get; }
    }
}