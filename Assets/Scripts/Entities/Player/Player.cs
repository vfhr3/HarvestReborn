using System;
using Core.Models;
using Core.Systems;
using Entities.Player.Data;
using Entities.Player.Input;
using UnityEngine;

namespace Entities.Player
{
    public class Player : Entity<PlayerContext>
    {
        private IInputSource _inputSource;
        
        public override void Initialize(PlayerContext context)
        {
            Debug.Log("Initializing Player...", this);
            _inputSource = new KeyBoardInput();
            
            base.Initialize(context);
            
            Debug.Log("Player Initialized!", this);
        }

        public void Update()
        {
            Context.Update(Time.deltaTime);
        }

        public void FixedUpdate()
        {
            Context.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}