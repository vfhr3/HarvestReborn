using Domain.Entities;

namespace Domain.StateMachine
{
    public interface IEntityState
    {
        public void Enter(IEntity context);
        public IEntityState Update(IEntity context, float deltaTime);
        public void Exit(IEntity context);
    }
}