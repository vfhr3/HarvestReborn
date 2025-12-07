using Domain.Container;
using Domain.Events;

namespace Domain.Entities.Player
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity(IEventBus events, EntityComponentContainer container) : base(events, container)
        {
        }
    }
}