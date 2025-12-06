using UnityEngine;


namespace Entities.Enemies.Systems
{
    public class TargetTracker : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private bool autoFindPlayer = true;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;

            if (autoFindPlayer && target == null)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player != null) target = player.transform;
            }
        }

        public Vector2 GetDirectionToTarget()
        {
            if (target == null) return Vector2.zero;

            return (target.position - _transform.position).normalized;
        }
        
        public float GetDistanceToTarget()
        {
            if (target == null) return float.MaxValue;
            return Vector2.Distance(_transform.position, target.position);
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public Transform GetTarget() => target;
    }
}