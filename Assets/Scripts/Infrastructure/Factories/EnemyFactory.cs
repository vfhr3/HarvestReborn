using Entities.Enemies;
using Entities.Enemies.Data;
using UnityEngine;

namespace Infrastructure.Factories
{
    public static class EnemyFactory
    {
        public static Enemy Create(Vector3 spawnPosition)
        {
            var enemyGO = Object.Instantiate(Resources.Load<Enemy>("Enemy/Enemy"), spawnPosition, Quaternion.identity);
            
            enemyGO.GetComponent<Enemy>()
                .Initialize(new EnemyContext(new EnemyConfig(), Vector2.zero));
            
            return enemyGO;
        }
    }
}