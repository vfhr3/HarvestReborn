using System;
using Core.Entity;

namespace Entities.Player.Data
{
    [Serializable]
    public class PlayerConfig : EntityConfig
    {
        public int StargingLevel { get; set; }
    }
}