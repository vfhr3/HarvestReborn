using Domain.Entities;
using Infrastructure.Configs;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class ContextFactory<TContext> where TContext : IEntity
    {
        public TContext From<TConfig>(TConfig config, Vector2 position)
            where TConfig : IEntityConfig<TContext>
        {
            var context = config.GetContext();
            context.UpdatePosition(position);
            return context;
        }
    }
}