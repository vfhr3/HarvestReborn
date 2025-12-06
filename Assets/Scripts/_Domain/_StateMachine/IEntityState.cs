using Abstractions.Entity;

namespace _Domain._StateMachine
{
    public interface IEntityState
    {
        public void Enter(IEntityContext context);
        public IEntityState Update(IEntityContext context, float deltaTime);
        public void Exit(IEntityContext context);
    }
}