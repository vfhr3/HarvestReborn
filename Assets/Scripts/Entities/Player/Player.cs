using Core.Entity;
using Core.Systems;
using Entities.Player.Data;
using Entities.Player.Input;
using UnityEngine;
using Utils;

namespace Entities.Player
{
    public class Player : Entity<PlayerContext, PlayerConfig>
    {
        private IInputSource _inputSource;
        private Entity<PlayerContext, PlayerConfig> _entityImplementation;
        
        public override void Initialize(PlayerContext context)
        {
            
        }
        
        protected override PlayerConfig CreateConfig()
        {
            return EntityConfigBuilder<PlayerConfig>.Create()
                .SetHealth(100)
                .SetMovementSpeed(5)
                .SetGracePeriodDuration(0.3f)
                .Build();
        }

        protected override PlayerContext CreateContext(PlayerConfig config)
        {
            return new PlayerContext(config, transform.position);
        }


        [ContextMenu("Take 10 Damage")]
        public void TakeDamage_Test()
        {
            Context.TakeDamage(10);
            Debug.Log(Context.Health.Current);
        }

    }
}