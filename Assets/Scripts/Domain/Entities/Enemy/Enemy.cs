using Infrastructure.Configs;

namespace Domain.Entities.Enemy
{
    public class Enemy : Entity
    {
        public Enemy(IEntityConfig<Enemy> config) : base(config)
        {
        }
    }
}