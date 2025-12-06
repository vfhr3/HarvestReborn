using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems
{
    public class EntityAnimation : ContextDrivenComponent<Entity>
    {
        private static readonly int HealthParam = Animator.StringToHash("Health");
        private static readonly int IsMovingParam = Animator.StringToHash("IsMoving");
        private static readonly int DeathTrigger = Animator.StringToHash("Death");
        
        [SerializeField] private Animator animator;

        private Entity _context;

        public override void Initialize(Entity entity)
        {
            _context = entity; 
            
            animator ??= GetComponent<Animator>();

            _context.Events.On<HealthChangedEvent>(UpdateHealthParameter);
            _context.Events.On<MovementStartedEvent>(HandleMovementStarted);
            _context.Events.On<MovementStoppedEvent>(HandleMovementStopped);
            _context.Events.On<DeathEvent>(PlayDeathAnimation);

            animator.SetInteger(HealthParam, _context.Health.Current);
        }

        public override void Cleanup()
        {
            _context.Events.Off<HealthChangedEvent>(UpdateHealthParameter);
            _context.Events.Off<MovementStartedEvent>(HandleMovementStarted);
            _context.Events.Off<MovementStoppedEvent>(HandleMovementStopped);
            _context.Events.Off<DeathEvent>(PlayDeathAnimation);
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

        private void PlayDeathAnimation(DeathEvent eventData)
        {
            animator.SetTrigger(DeathTrigger);
        }
    }
}