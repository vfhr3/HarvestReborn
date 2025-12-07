using System;
using Domain.Entities.Player;
using Presentation.Core;
using UnityEngine;


namespace Presentation.Player
{
    public class PlayerView : MonoBehaviour, IEntityComponentView<PlayerEntity>
    {
        private PlayerEntity _player;
        
        public void Initialize(PlayerEntity context)
        {
            _player = context;
        }

        private void Update()
        {
            _player.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _player.FixedUpdate(Time.fixedDeltaTime);
        }

        public void Cleanup()
        {
            
        }
    }
}