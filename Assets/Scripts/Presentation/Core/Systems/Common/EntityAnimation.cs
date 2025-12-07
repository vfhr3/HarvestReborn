using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems.Common
{
    public class EntityAnimation : MonoBehaviour, IEntityComponentView<Entity>
    {
        private static readonly int IsMovingParam = Animator.StringToHash("IsMoving");
        private static readonly int DeathTrigger = Animator.StringToHash("Death");
        
        private Entity _context;
        
        [SerializeField] private Animator animator;
        
        public void Initialize(Entity context)
        {
            _context = context; 
            
            animator ??= GetComponent<Animator>();

            _context.Events.On<MovementStartedEvent>(HandleMovementStarted);
            _context.Events.On<MovementStoppedEvent>(HandleMovementStopped);
            _context.Events.On<DeathEvent>(PlayDeathAnimation);
        }

        public void Cleanup()
        {
            _context.Events.Off<MovementStartedEvent>(HandleMovementStarted);
            _context.Events.Off<MovementStoppedEvent>(HandleMovementStopped);
            _context.Events.Off<DeathEvent>(PlayDeathAnimation);
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