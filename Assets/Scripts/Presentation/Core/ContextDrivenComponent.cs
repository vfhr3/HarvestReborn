using UnityEngine;

namespace Presentation.Core
{
    public abstract class ContextDrivenComponent<T> : MonoBehaviour, IInitializable<T>
    {
        public abstract void Initialize(T entity);
        public abstract void Cleanup();
    }

    public interface IInitializable <in T>
    {
        public void Initialize(T entity);
        public void Cleanup();
    }
}