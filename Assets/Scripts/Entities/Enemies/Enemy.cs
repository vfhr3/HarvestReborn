using Core.Systems;
using Entities.Enemies.Data;
using Entities.Enemies.Systems;
using UnityEngine;
using Utils;

namespace Entities.Enemies
{
    public class Enemy : BaseEntity<EnemyContext, EnemyConfig>
    {
        private TargetTracker _targetTracker;

        protected override void Awake()
        {
            _targetTracker = GetComponent<TargetTracker>();

            if (_targetTracker == null)
            {
                _targetTracker = gameObject.AddComponent<TargetTracker>();
            }
            
            base.Awake();
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

        protected override Vector2 GetMovementDirection()
        {
            return _targetTracker.GetDirectionToTarget();
        }
    }
}