using UnityEngine;

namespace Infrastructure.Input
{
    public class KeyBoardInput : IInputSource
    {
        public Vector2 GetDirection()
        {
            return new Vector2(
                UnityEngine.Input.GetAxisRaw("Horizontal"),
                UnityEngine.Input.GetAxisRaw("Vertical")
            ).normalized;
        }
    }
}