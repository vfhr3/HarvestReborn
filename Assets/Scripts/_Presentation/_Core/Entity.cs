using Abstractions;
using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public abstract class Entity<TContext> : ContextDrivenComponent<TContext> where TContext : EntityContext
    {
        [SerializeField] protected TContext context;
        
        public TContext Context => context;
        public override void Initialize(TContext entityContext)
        {
            context = entityContext;
            
            foreach (var component in GetComponents<ContextDrivenComponent<EntityContext>>())
            {
                component.Initialize(context);
            }
        }

        public override void Cleanup()
        {
            foreach (var component in GetComponents<ContextDrivenComponent<EntityContext>>())
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