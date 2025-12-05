using Abstractions.Entity;
using UnityEngine;

namespace Abstractions
{
    public abstract class DataDrivenComponent<T> : MonoBehaviour, IInitializable<T> where T : IEntityContext
    {
        public abstract void Initialize(T data);
    }

    public interface IInitializable <in T>
    {
        public void Initialize(T data);
    }
}