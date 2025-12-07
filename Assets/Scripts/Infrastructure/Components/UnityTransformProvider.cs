
using Domain.Components;
using UnityEngine;

namespace Infrastructure.Components
{
    public class UnityTransformProvider : ITransformProvider
    {
        private readonly Transform _transform;

        public UnityTransformProvider(Transform transform)
        {
            _transform = transform;
        }

        public Vector2 Position
        {
            get => _transform.position;
            set => _transform.position = new Vector3(value.x, value.y, _transform.position.z);
        }

        public Vector2 LocalPosition
        {
            get => _transform.localPosition;
            set => _transform.position = new Vector3(value.x, value.y, _transform.localPosition.z);
        }
    }
}