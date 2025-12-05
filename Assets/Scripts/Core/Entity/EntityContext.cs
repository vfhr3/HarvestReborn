using System;
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
        public readonly EntityStateMachine MovementState;
        public readonly GracePeriod GracePeriod;
        private readonly Health _health;
        public readonly Movement Movement;
        public Vector2 Position;
        
        private bool _isFacingRight = true;

        protected EntityContext(EntityConfig config, Vector2 initialPosition)
        {
            _health = new Health(config.MaxHealth);
            GracePeriod = new GracePeriod(config.GracePeriodDuration);
            Movement = new Movement(config.MovementSpeed);
            Position = initialPosition;
            
            Events = new EventBus();
            MovementState = new EntityStateMachine(this, new IdleState());
        }

        // Health Exposed
        public bool IsDead => _health.IsDead;
        public Health Health => _health;
        public bool IsMoving => Movement.Direction.magnitude > 0;


        public EventBus Events { get; }

        public void TakeDamage(int damage)
        {
            if (GracePeriod.IsActive || IsDead) return;

            var oldHealth = _health.Current;
            _health.TakeDamage(damage);
            Events.Emit(new DamageTakenEvent(damage, oldHealth, _health.Current, _health.IsDead));
            Events.Emit(new HealthChangedEvent(Math.Abs(oldHealth - _health.Current), oldHealth, _health.Current));
            StartGracePeriod();
            
            if (IsDead) Events.Emit(new DeathEvent());
        }

        public virtual void Update(float deltaTime)
        {
            GracePeriod.Update(deltaTime);
            MovementState.Update(deltaTime);
        }

        public virtual void FixedUpdate(float fixedDeltaTime)
        {
            Move(fixedDeltaTime);
        }

        private void Move(float fixedDeltaTime)
        {
            var oldPosition = Position;
            var newPosition = oldPosition + Movement.Direction * (Movement.Speed * fixedDeltaTime);

            if (IsMoving)
            {
                Position = newPosition;
                Events.Emit(new PositionChangedEvent(oldPosition, newPosition));
            }
        }

        public void UpdateDirection(Vector2 direction)
        {
            Movement.Direction = direction;

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

        private void StartGracePeriod()
        {
            if (GracePeriod.IsActive) return;
            GracePeriod.Start();
            Events.Emit(new GracePeriodStartedEvent(GracePeriod.Duration));
        }
    }
}