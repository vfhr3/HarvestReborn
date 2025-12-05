using Abstractions;
using Core.Entity;
using Events.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class EntityAnimation : ContextDrivenComponent<EntityContext>
    {
        private static readonly int HealthParam = Animator.StringToHash("Health");
        private static readonly int IsMovingParam = Animator.StringToHash("IsMoving");
        private static readonly int DeathTrigger = Animator.StringToHash("Death");
        
        [SerializeField] private Animator animator;

        private EntityContext _context;

        private void OnDestroy()
        {
            if (_context != null)
            {
                _context.Events.Off<HealthChangedEvent>(UpdateHealthParameter);
                _context.Events.Off<MovementStartedEvent>(HandleMovementStarted);
                _context.Events.Off<MovementStoppedEvent>(HandleMovementStopped);
                _context.Events.Off<DeathEvent>(PlayDeathAnimation);
            }
        }

        public override void Initialize(EntityContext context)
        {
            _context = context;

            if (animator == null)
                animator = GetComponent<Animator>();

            _context.Events.On<HealthChangedEvent>(UpdateHealthParameter);
            _context.Events.On<MovementStartedEvent>(HandleMovementStarted);
            _context.Events.On<MovementStoppedEvent>(HandleMovementStopped);
            _context.Events.On<DeathEvent>(PlayDeathAnimation);

            animator.SetInteger(HealthParam, _context.Health.Current);
        }

        private void UpdateHealthParameter(HealthChangedEvent eventData)
        {
            animator.SetInteger(HealthParam, eventData.CurrentHealth);
        }

        private void HandleMovementStarted(MovementStartedEvent eventData)
        {
            animator.SetBool(IsMovingParam, true);
        }

        private void HandleMovementStopped(MovementStoppedEvent eventData)
        {
            animator.SetBool(IsMovingParam, false);
        }

        public void PlayDeathAnimation(DeathEvent eventData)
        {
            animator.SetTrigger(DeathTrigger);
        }
    }
}