using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Events
{
    public class EventBus
    {
        private readonly ConcurrentDictionary<Type, List<Delegate>> _listeners = new();
        private readonly object _lock = new();

        public void On<TEvent>(Action<TEvent> callback) where TEvent : IEventData
        {
            if (callback == null) throw new ArgumentNullException(nameof(callback));
            var type = typeof(TEvent);
            _listeners.AddOrUpdate(type, _ => new List<Delegate> { callback },
                (_, list) =>
                {
                    lock (_lock)
                    {
                        list.Add(callback);
                    }

                    return list;
                });
        }

        public void Off<TEvent>(Action<TEvent> callback) where TEvent : IEventData
        {
            if (callback == null) throw new ArgumentNullException(nameof(callback));

            var type = typeof(TEvent);
            if (!_listeners.TryGetValue(type, out var list))
                throw new InvalidOperationException($"No listeners registered for {type.Name}");

            lock (_lock)
            {
                if (!list.Remove(callback))
                    throw new InvalidOperationException($"Listener not found for type {type.Name}");
            }
        }

        public void Emit<TEvent>(TEvent eventParams) where TEvent : IEventData
        {
            if (eventParams == null)
                throw new ArgumentNullException(nameof(eventParams));

            var type = typeof(TEvent);
            _listeners.TryGetValue(type, out var list);
            if (list != null)
            {
                List<Delegate> copy;
                lock (_lock)
                {
                    copy = new List<Delegate>(list);
                }

                foreach (var callback in copy) ((Action<TEvent>)callback)?.Invoke(eventParams);
            }
        }
    }

    public interface IEventData
    {
    }
}