using Abstractions;
using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public abstract class BaseEntity<TContext, TConfig> : MonoBehaviour, IEntity 
        where TContext : EntityContext
        where TConfig : class
    {
        protected TConfig Config;
        public TContext Context;

        public bool IsDead => Context.IsDead;

        protected virtual void Awake()
        {
            Config = CreateConfig();
            Context = CreateContext(Config);
            Initialize();
        }

        protected virtual void Update()
        {
            Context.Update(Time.deltaTime);
        }

        protected virtual void FixedUpdate()
        {
            var direction = GetMovementDirection();
            Context.UpdateDirection(direction);
            Context.FixedUpdate(Time.fixedDeltaTime);
        }

        public void Initialize()
        {
            foreach (var system in GetComponents<DataDrivenComponent<EntityContext>>())
            {
                system.Initialize(Context);
            }

            var movement = GetComponent<EntityMovement>();
            var rb = GetComponent<Rigidbody2D>();

            if (movement != null && rb != null)
            {
                movement.Initialize(rb, Context);
            }
        }
        protected abstract TConfig CreateConfig();
        protected abstract TContext CreateContext(TConfig config);
        protected abstract Vector2 GetMovementDirection();
    }
}