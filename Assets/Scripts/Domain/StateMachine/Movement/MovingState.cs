using Domain.Entities.Interfaces;
using UnityEngine;

namespace Domain.StateMachine.Movement
{
    public class MovingState: IEntityState<IMoveable>
    {
        public void Enter(IMoveable context)
        {
            Debug.Log($"Entered {GetType().Name}");
        }

        public IEntityState<IMoveable> Update(IMoveable context, float deltaTime)
        {
            if (context.Direction.sqrMagnitude == 0) 
                return new IdleState();
            
            var newPosition = context.Position + context.Direction * context.Speed * deltaTime;
            context.UpdatePosition(newPosition);
            
            return this;
        }

        public void Exit(IMoveable context)
        {
            
        }
    }
}
