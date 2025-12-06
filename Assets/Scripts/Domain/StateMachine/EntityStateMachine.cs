namespace Domain.StateMachine
{
    public class EntityStateMachine<T>
    {
        private readonly T _context;

        public EntityStateMachine(T context, IEntityState<T> initialState)
        {
            _context = context;
            ChangeState(initialState);
        }

        private IEntityState<T> Current { get; set; }

        private void ChangeState(IEntityState<T> newState)
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