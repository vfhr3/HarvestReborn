using _Infrastructure._Input;
using Core.Systems;
using Entities.Player.Data;
using Entities.Player.Input;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entity<PlayerContext>
    {
        private IInputSource _inputSource;
        
        public override void Initialize(PlayerContext playerContext)
        {
            Debug.Log("Initializing Player...", this);
            _inputSource = new KeyBoardInput();
            
            base.Initialize(playerContext);
            
            Debug.Log("Player Initialized!", this);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            context.UpdateDirection(_inputSource.GetDirection());

            base.FixedUpdate();
        }
    }
}