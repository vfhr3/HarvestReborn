using Domain.Entities;

namespace Infrastructure.Configs
{
    public interface IEntityConfig<out TContext> where TContext : IEntity
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; }

        public TContext GetContext();
    }
}