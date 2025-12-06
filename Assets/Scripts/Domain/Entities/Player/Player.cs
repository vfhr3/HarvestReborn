using Infrastructure.Configs;

namespace Domain.Entities.Player
{
    public class Player : Entity
    {
        public Player(PlayerConfig config) : base(config)
        {
        }
    }
}