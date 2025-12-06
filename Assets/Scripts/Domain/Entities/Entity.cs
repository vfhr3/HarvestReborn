using System;
using Domain.Models;
using Domain.StateMachine;
using Domain.StateMachine.Life;
using Domain.StateMachine.Movement;
using Infrastructure.Configs;
using Infrastructure.Events;
using UnityEngine;

namespace Domain.Entities
{
    [Serializable]
    public abstract class Entity : IEntity
    {
        public bool IsMoving { get; set; }
        public float Speed { get; }
        public Vector2 Direction { get; private set; }
        public Vector2 Position { get; private set; }
        public Health Health { get; }
        public MovementData Movement { get; }
        public EntityStateMachine MovementState { get; }
        public EntityStateMachine LifeState { get; }
        public IEventBus Events { get; }
        
        protected Entity(IEntityConfig<Entity> config)
        {
            Events = new EventBus();
            Speed = config.Speed;
            Direction = Vector2.zero;
            Health = new Health(config.MaxHealth);
            Movement = new MovementData(config.Speed);
            LifeState = new EntityStateMachine(this, new AliveState());
            MovementState = new EntityStateMachine(this, new IdleState());
        }
        
        public virtual void Update(float deltaTime)
        {
            LifeState.Update(deltaTime);
        }

        public virtual void FixedUpdate(float fixedDeltaTime)
        {
            MovementState.Update(fixedDeltaTime);
        }

        public void UpdatePosition(Vector2 position)
        {
            Position = position;
        }

        public void UpdateDirection(Vector2 direction)
        {
            Direction = direction;
        }
    }
}