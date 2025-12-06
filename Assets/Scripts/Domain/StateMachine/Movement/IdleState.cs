using Domain.Entities;
using Domain.Entities.Interfaces;
using Domain.Events.Entity;
using UnityEngine;

namespace Domain.StateMachine.Movement
{
    public class IdleState : IEntityState<IMoveable>
    {

        public void Enter(IMoveable context)
        {
        }

        public IEntityState<IMoveable> Update(IMoveable context, float deltaTime)
        {
            if (context.Direction.magnitude > 0)
            {
                return new MovingState();
            }
            return this;
        }

        public void Exit(IMoveable context)
        {
        }
    }
}