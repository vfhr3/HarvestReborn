using UnityEngine;

namespace Abstractions
{
    public abstract class ContextDrivenComponent<T> : MonoBehaviour, IInitializable<T>
    {
        public abstract void Initialize(T context);
        public abstract void Cleanup();
    }

    public interface IInitializable <in T>
    {
        public void Initialize(T playerContext);
        public void Cleanup();
    }
}