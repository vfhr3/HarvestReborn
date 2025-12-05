using Core.Systems;
using Entities.Enemies.Data;
using Entities.Enemies.Systems;
using Utils;

namespace Entities.Enemies
{
    public class Enemy : Entity<EnemyContext, EnemyConfig>
    {
        private TargetTracker _targetTracker;

        public override void Initialize(EnemyContext context)
        {
            throw new System.NotImplementedException();
        }

        protected override EnemyConfig CreateConfig()
        {
            return EntityConfigBuilder<EnemyConfig>.Create()
                .SetHealth(50)
                .SetMovementSpeed(4.5f)
                .SetGracePeriodDuration(0)
                .Build();
        }

        protected override EnemyContext CreateContext(EnemyConfig config)
        {
            return new EnemyContext(config, transform.position);
        }

    }
}