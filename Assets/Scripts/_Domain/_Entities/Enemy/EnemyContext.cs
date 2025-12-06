using Core.Entity;
using UnityEngine;

namespace Entities.Enemies.Data
{
    public class EnemyContext : EntityContext
    {
        public EnemyContext(IEntityConfig<EnemyContext> config) : base(config)
        {
        }
    }
}