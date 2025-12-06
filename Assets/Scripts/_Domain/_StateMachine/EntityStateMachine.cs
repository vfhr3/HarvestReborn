using _Domain._StateMachine;
using Abstractions.Entity;

namespace Core.StateMachine
{
    public class EntityStateMachine
    {
        private readonly IEntityContext _context;

        public EntityStateMachine(IEntityContext context, IEntityState initialState)
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