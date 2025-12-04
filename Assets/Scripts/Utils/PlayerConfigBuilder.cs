using Core.Entity;

namespace Utils
{
    public class EntityConfigBuilder<T> where T : EntityConfig, new()
    {
        private readonly T _instance = new();

        private EntityConfigBuilder()
        {
        }

        public static EntityConfigBuilder<T> Create()
        {
            return new EntityConfigBuilder<T>();
        }

        public EntityConfigBuilder<T> SetHealth(int health)
        {
            _instance.MaxHealth = health;
            return this;
        }

        public EntityConfigBuilder<T> SetMovementSpeed(float movementSpeed)
        {
            _instance.MovementSpeed = movementSpeed;
            return this;
        }

        public EntityConfigBuilder<T> SetGracePeriodDuration(float duration)
        {
            _instance.GracePeriodDuration = duration;
            return this;
        }

        public T Build()
        {
            return _instance;
        }
    }
}