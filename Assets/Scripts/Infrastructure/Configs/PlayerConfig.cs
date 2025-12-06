using System;
using Domain.Entities.Player;

namespace Infrastructure.Configs
{
    [Serializable]
    public class PlayerConfig : IEntityConfig<Player>
    {
        public int MaxHealth { get; set; }
        public float GracePeriodDuration { get; set; }
        public float Speed { get; set; } = 5;
        public Player GetContext()
        {
            return new Player(this);
        }
    }
}