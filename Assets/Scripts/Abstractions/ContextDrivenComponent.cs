using Core.Entity;
using UnityEngine;

namespace Abstractions
{
    public abstract class ContextDrivenComponent<T> : MonoBehaviour, IInitializable<T>
    {
        public abstract void Initialize(T context);
    }

    public interface IInitializable <in T>
    {
        public void Initialize(T data);
    }
}