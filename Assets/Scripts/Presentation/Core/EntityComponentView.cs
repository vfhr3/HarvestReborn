using UnityEngine;

namespace Presentation.Core
{
    public interface IEntityComponentView<in T>
    {
        void Initialize(T context);
        void Cleanup();
    }
}