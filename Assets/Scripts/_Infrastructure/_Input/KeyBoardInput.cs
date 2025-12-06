using Entities.Player.Input;
using UnityEngine;

namespace _Infrastructure._Input
{
    public class KeyBoardInput : IInputSource
    {
        public Vector2 GetDirection()
        {
            return new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            ).normalized;
        }
    }
}