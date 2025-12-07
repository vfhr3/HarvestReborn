using UnityEngine;

namespace Domain.Components
{
    public interface ITransformProvider
    {
        Vector2 Position { get; set; }
        Vector2 LocalPosition { get; set; } 
    }
}