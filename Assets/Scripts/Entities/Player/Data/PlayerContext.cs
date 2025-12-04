using System;
using Core.Entity;
using UnityEngine;

namespace Entities.Player.Data
{
    [Serializable]
    public class PlayerContext : EntityContext
    {
        public PlayerContext(PlayerConfig config, Vector2 initialPosition) : base(config, initialPosition)
        {
        }
    }
}