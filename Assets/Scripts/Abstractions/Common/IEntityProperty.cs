using Events;

namespace Abstractions.Common
{
    public interface IEntityProperty
    {
        public EventBus Events { get; }
    }
}