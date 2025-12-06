using Domain.Events;

namespace Domain.Entities.Enemy
{
    public class EnemyEntity : Entity
    {
        public EnemyEntity(IEventBus events) : base(events)
        {
        }
    }
}