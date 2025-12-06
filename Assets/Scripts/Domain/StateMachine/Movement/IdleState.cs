using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Domain.StateMachine.Movement
{
    public class IdleState : IEntityState
    {
        public void Enter(IEntity context)
        {
            Debug.Log("Entered Idle State");
            context.Events.Emit(new MovementStoppedEvent());
        }

        public IEntityState Update(IEntity context, float deltaTime)
        {
            if (context.Direction.magnitude > 0)
            {
                context.IsMoving = true;
                return new MovingState();
            }
            return this;
        }

        public void Exit(IEntity context)
        {
            
        }
    }
}