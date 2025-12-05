using System;
using Core.Entity;

namespace Entities.Player.Data
{
    [Serializable]
    public class PlayerConfig : IEntityConfig<PlayerContext>
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; } = 5;
        public PlayerContext GetContext()
        {
            return new PlayerContext(this);
        }
    }
}