using Core.Entity;

namespace Entities.Enemies.Data
{
    public class EnemyConfig : IEntityConfig<EnemyContext>
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; }
        public EnemyContext GetContext()
        {
            return new EnemyContext(this);
        }
    }
}