using Domain.Entities;

namespace Domain.StateMachine
{
    public interface IEntityState<T>
    {
        public void Enter(T context);
        public IEntityState<T> Update(T context, float deltaTime);
        public void Exit(T context);
    }
}