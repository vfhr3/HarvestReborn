using Domain.Entities.Player;
using Presentation.Core;
using UnityEngine;


namespace Presentation.Player
{
    public class PlayerView : EntityComponentView<PlayerEntity>
    {
        private PlayerEntity _player;
        public override void Initialize(PlayerEntity context)
        {
            _player = context;
        }

        public override void Cleanup()
        {
            
        }

        private void Update()
        {
            _player.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _player.FixedUpdate(Time.deltaTime);
        }
    }
}