namespace Events.Entity
{
    public class DamageTakenEvent : IEventData
    {
        public DamageTakenEvent(int damageTaken, int oldHealth, int currentHealth, bool isDead)
        {
            Damage = damageTaken;
            OldHealth = oldHealth;
            CurrentHealth = currentHealth;
            IsDead = isDead;
        }

        public int Damage { get; set; }
        public int OldHealth { get; set; }
        public int CurrentHealth { get; set; }
        public bool IsDead { get; set; }
    }
}