using Core.Systems;
using Entities.Player.Data;
using Entities.Player.Input;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Entities.Player
{
    public class Player : BaseEntity<PlayerContext, PlayerConfig>
    {
        private IInputSource _inputSource;
        protected override PlayerConfig CreateConfig()
        {
            return EntityConfigBuilder<PlayerConfig>.Create()
                .SetHealth(100)
                .SetMovementSpeed(5)
                .SetGracePeriodDuration(0.3f)
                .Build();
        }

        protected override void Awake()
        {
            _inputSource = new KeyBoardInput();
            base.Awake();
        }

        protected override PlayerContext CreateContext(PlayerConfig config)
        {
            return new PlayerContext(config, transform.position);
        }

        protected override Vector2 GetMovementDirection()
        {
            return _inputSource.GetDirection();
        }

        [ContextMenu("Take 10 Damage")]
        public void TakeDamage_Test()
        {
            Context.TakeDamage(10);
            Debug.Log(Context.Health.Current);
        }
    }
}