using Domain.Components;
using Domain.Container;
using Domain.Events;

namespace Domain.Entities.Enemy
{
    public class EnemyEntity : Entity
    {
        public EnemyEntity(IEventBus events, EntityComponentContainer container) : base(events, container)
        {
        }
    }
}