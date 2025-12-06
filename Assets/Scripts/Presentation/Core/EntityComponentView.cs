using UnityEngine;

namespace Presentation.Core
{
    public abstract class EntityComponentView<T> : MonoBehaviour, IInitializable<T>
    {
        public abstract void Initialize(T context);

        public abstract void Cleanup();
    }

    public interface IInitializable <in T>
    {
        public void Initialize(T context);
        public void Cleanup();
    }
}