using Abstractions.Entity;

namespace Core.Entity
{
    public interface IEntityConfig<out TContext> where TContext : IEntityContext
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; }

        public TContext GetContext();
    }
}