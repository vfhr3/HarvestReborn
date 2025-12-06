using System;
using Domain.Events;
using Infrastructure.Events;

namespace Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        IEventBus Events { get; }
        
    }
}