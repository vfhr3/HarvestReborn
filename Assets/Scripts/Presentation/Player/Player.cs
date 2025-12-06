using Infrastructure.Input;
using Presentation.Core;
using UnityEngine;

namespace Presentation.Player
{
    public class Player : Entity<Domain.Entities.Player.Player>
    {
        private IInputSource _inputSource;
        
        public override void Initialize(Domain.Entities.Player.Player entity)
        {
            Debug.Log("Initializing Player...", this);
            _inputSource = new KeyBoardInput();
            
            base.Initialize(entity);
            
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