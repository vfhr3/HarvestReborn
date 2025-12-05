using Core.Entity;
using UnityEngine;

namespace Abstractions.Common
{
    public interface IMoveable
    {
        public bool IsMoving { get; set; }
        public EntityContext Context { get; set; }
        void Move(Vector2 direction);
    }
}