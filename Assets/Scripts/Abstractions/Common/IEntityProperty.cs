using Core.Entity;
using Events;

namespace Abstractions
{
    public interface IEntityProperty
    {
        public EventBus Events { get; }
    }
}