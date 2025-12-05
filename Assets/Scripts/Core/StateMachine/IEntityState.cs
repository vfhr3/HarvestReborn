using Abstractions.Entity;

namespace Core.StateMachine
{
    public interface IEntityState
    {
        public void Enter(IEntityContext context);
        public IEntityState Update(IEntityContext context, float deltaTime);
        public void Exit(IEntityContext context);
    }
}