using UnityEngine;

namespace Entities.Player.Input
{
    public interface IInputSource
    {
        public Vector2 GetDirection();
    }
}