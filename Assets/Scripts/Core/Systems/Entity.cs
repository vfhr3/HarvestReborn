using System;
using Abstractions;
using Core.Entity;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Systems
{
    public abstract class Entity<TContext> : ContextDrivenComponent<TContext> where TContext : EntityContext
    {
        [SerializeField] protected TContext context;
        public TContext Context => context;
        public override void Initialize(TContext entityContext)
        {
            Debug.Log("Initializing Entity...", this);
            this.context = entityContext;
            foreach (var component in GetComponents<ContextDrivenComponent<EntityContext>>())
            {
                component.Initialize(context);
            }

            Debug.Log("Entity Initialized!", this);
        }
    }
}