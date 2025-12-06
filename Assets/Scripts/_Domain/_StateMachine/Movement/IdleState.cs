using _Domain._StateMachine;
using Abstractions.Entity;
using Events.Entity;
using UnityEngine;

namespace Core.StateMachine.Movement
{
    public class IdleState : IEntityState
    {
        public void Enter(IEntityContext context)
        {
            Debug.Log("Entered Idle State");
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState Update(IEntityContext context, float deltaTime)
        {
            if (context.Direction.magnitude > 0)
            {
                context.IsMoving = true;
                return new MovingState();
            }
            return this;
        }

        public void Exit(IEntityContext context)
        {
            
        }
    }
}