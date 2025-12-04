using Core.Entity;
using UnityEngine;

namespace Entities.Enemies.Data
{
    public class EnemyContext : EntityContext
    {
        public EnemyContext(EnemyConfig config, Vector2 initialPosition) : base(config, initialPosition) { }
    }
}