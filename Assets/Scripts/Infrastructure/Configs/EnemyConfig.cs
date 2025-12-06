using Domain.Entities.Enemy;

namespace Infrastructure.Configs
{
    public class EnemyConfig : IEntityConfig<Enemy>
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; }
        public Enemy GetContext()
        {
            return new Enemy(this);
        }
    }
}