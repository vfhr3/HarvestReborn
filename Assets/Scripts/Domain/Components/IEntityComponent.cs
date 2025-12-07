using Domain.Events;

namespace Domain.Components
{
    public interface IEntityComponent
    {
        public IEventBus Events { get; }
        public void Initialize( );
        public void Update(float deltaTime);
        public void FixedUpdate(float fixedDeltaTime);
        public void Cleanup();
    }
}