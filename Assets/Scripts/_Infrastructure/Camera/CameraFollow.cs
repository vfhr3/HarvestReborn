using Entities.Player;
using UnityEngine;

namespace Infrastructure.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public float SmoothTime;

        private Transform _target;
        private Vector3 _velocity = Vector3.zero;

        public void Start()
        {
            _target = FindFirstObjectByType<Player>().transform;
        }

        private void Update()
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                new Vector3(_target.position.x, _target.position.y, transform.position.z),
                ref _velocity,
                SmoothTime);
        }
    }
}