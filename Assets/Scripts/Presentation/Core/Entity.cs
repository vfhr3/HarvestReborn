using Domain.Entities;
using UnityEngine;

namespace Presentation.Core
{
    public abstract class Entity<TContext> : ContextDrivenComponent<TContext> where TContext : Entity
    {
        [SerializeField] protected TContext context;
        
        public TContext Context => context;
        public override void Initialize(TContext entity)
        {
            context = entity;
            
            foreach (var component in GetComponents<ContextDrivenComponent<Entity>>())
            {
                component.Initialize(context);
            }
        }

        public override void Cleanup()
        {
            foreach (var component in GetComponents<ContextDrivenComponent<Entity>>())
            {
                component.Cleanup();
            }
        }

        public virtual void Update()
        {
            var deltaTime = Time.deltaTime;
            context.Update(deltaTime);
        }

        public virtual void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            context.FixedUpdate(deltaTime);
        }
    }
}