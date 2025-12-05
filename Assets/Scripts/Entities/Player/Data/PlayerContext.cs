using Core.Entity;
using UnityEngine;

namespace Entities.Player.Data
{
    public class PlayerContext : EntityContext
    {
        public PlayerContext(PlayerConfig config) : base(config)
        {
        }
    }
}