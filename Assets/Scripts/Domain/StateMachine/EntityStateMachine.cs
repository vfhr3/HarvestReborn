using Domain.Entities;

namespace Domain.StateMachine
{
    public class EntityStateMachine
    {
        private readonly IEntity _context;

        public EntityStateMachine(IEntity context, IEntityState initialState)
        {
            _context = context;
            ChangeState(initialState);
        }

        private IEntityState Current { get; set; }

        private void ChangeState(IEntityState newState)
        {
            Current?.Exit(_context);
            Current = newState;
            Current?.Enter(_context);
        }

        public void Update(float deltaTime)
        {
            var newState = Current?.Update(_context, deltaTime);

            if (newState != null && newState != Current)
                ChangeState(newState);
        }
    }
}