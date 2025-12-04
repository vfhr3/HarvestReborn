using Core.Entity;

namespace Core.StateMachine
{
    public interface IEntityState
    {
        public void Enter(EntityContext context);
        public IEntityState Update(EntityContext context, float deltaTime);
        public void Exit(EntityContext context);
    }
}