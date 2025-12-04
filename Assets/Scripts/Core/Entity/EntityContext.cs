using Abstractions;
using Core.Models;
using Core.StateMachine;
using Events;
using Events.Entity;
using UnityEngine;

namespace Core.Entity
{
    public abstract class EntityContext : IDamageable
    {
        private readonly EntityStateMachine _movementState;
        private readonly GracePeriod _gracePeriod;
        private readonly Health _health;
        private readonly Movement _movement;
        private Vector2 _position;
        
        private bool _isFacingRight = true;

        protected EntityContext(EntityConfig config, Vector2 initialPosition)
        {
            _health = new Health(config.MaxHealth);
            _gracePeriod = new GracePeriod(config.GracePeriodDuration);
            _movement = new Movement(config.MovementSpeed);
            _position = initialPosition;
            
            Events = new EventBus();
            _movementState = new EntityStateMachine(this, new IdleState());
        }

        // Health Exposed
        public bool IsDead => _health.IsDead;
        public Health Health => _health;
        public bool IsMoving => _movement.Direction.magnitude > 0;


        public EventBus Events { get; }

        public void TakeDamage(int damage)
        {
            if (_gracePeriod.IsActive || IsDead) return;

            var oldHealth = _health.Current;
            _health.TakeDamage(damage);
            Events.Emit(new DamageTakenEvent(damage, oldHealth, _health.Current, _health.IsDead));
        }

        public virtual void Update(float deltaTime)
        {
            _gracePeriod.Update(deltaTime);
            _movementState.Update(deltaTime);
        }

        public virtual void FixedUpdate(float fixedDeltaTime)
        {
            Move(fixedDeltaTime);
        }

        private void Move(float fixedDeltaTime)
        {
            var oldPosition = _position;
            var newPosition = oldPosition + _movement.Direction * (_movement.Speed * fixedDeltaTime);

            if (IsMoving)
            {
                _position = newPosition;
                Events.Emit(new PositionChangedEvent(oldPosition, newPosition));
            }
        }

        public void UpdateDirection(Vector2 direction)
        {
            _movement.Direction = direction;

            if (direction.x != 0)
            {
                var newFacingRight = direction.x > 0;
                if (newFacingRight != _isFacingRight)
                {
                    _isFacingRight = newFacingRight;
                    Events.Emit(new DirectionChangedEvent(_isFacingRight));
                }
            }
        }
    }
}