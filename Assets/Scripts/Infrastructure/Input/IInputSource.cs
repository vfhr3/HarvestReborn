using UnityEngine;

namespace Infrastructure.Input
{
    public interface IInputSource
    {
        public Vector2 GetDirection();
    }
}