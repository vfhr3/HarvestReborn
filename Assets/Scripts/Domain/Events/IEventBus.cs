using System;

namespace Domain.Events
{
    public interface IEventBus
    {
        public void On<TEvent>(Action<TEvent> callback) where TEvent : IEventData;
        public void Emit<TEvent>(TEvent e) where TEvent : IEventData;
        public void Off<TEvent>(Action<TEvent> callback) where TEvent : IEventData;
    }
}