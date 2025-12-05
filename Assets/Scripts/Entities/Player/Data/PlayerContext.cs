using System;
using Core.Entity;
using Core.Models;
using Events.Level;
using UnityEngine;

namespace Entities.Player.Data
{
    [Serializable]
    public class PlayerContext : EntityContext
    {
        private readonly Experience _experience;
        public PlayerContext(PlayerConfig config, Vector2 initialPosition) : base(config, initialPosition)
        {
            _experience = new Experience(config.StargingLevel);
        }

        public Experience Experience => _experience;

        public void GainExperience(int amount)
        {
            if (amount <= 0 || IsDead) return;
            
            _experience.AddExperience(amount);
            Events.Emit(new ExperienceGainEvent(amount, _experience.Current));
            while (_experience.TryLevelUp())
            {
                var oldLevel = _experience.Level;
                _experience.TryLevelUp();
                Events.Emit(new LevelUpEvent(oldLevel, _experience.Level));
            }
        }
    }
}