using Abstractions;
using Core.Entity;
using UnityEngine;

namespace Core.Systems
{
    public abstract class Entity<TContext, TConfig> : ContextDrivenComponent<TContext>
        where TContext : EntityContext
        where TConfig : class
    {
        protected TConfig Config;
        public TContext Context;
        protected virtual void Update()
        {
            Context.Update(Time.deltaTime);
        }

        protected virtual void Initialize()
        {
            
        }
        
        protected abstract TConfig CreateConfig();
        protected abstract TContext CreateContext(TConfig config);
    }
}