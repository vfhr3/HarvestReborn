using Entities.Player.Data;
using Utils;

namespace Entities.Player
{
    public static class CharacterConfigs
    {
        public static readonly PlayerConfig Default = EntityConfigBuilder<PlayerConfig>.Create()
            .SetHealth(100)
            .SetMovementSpeed(5)
            .SetGracePeriodDuration(0.3f)
            .Build();
    }
}