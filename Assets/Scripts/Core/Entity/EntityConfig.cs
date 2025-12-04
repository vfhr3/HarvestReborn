namespace Core.Entity
{
    public abstract class EntityConfig
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; } = 0;
        public float MovementSpeed { get; set; } = 1;
    }
}