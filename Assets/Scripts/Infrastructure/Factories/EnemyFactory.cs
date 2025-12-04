using Entities.Enemies;
using UnityEngine;

namespace Infrastructure.Factories
{
    public static class EnemyFactory
    {
        public static Enemy Create(Vector3 spawnPosition)
        {
            var enemyGO = Object.Instantiate(Resources.Load<Enemy>("Enemy/Enemy"), spawnPosition, Quaternion.identity);
            
            enemyGO.GetComponent<Enemy>()
                .Initialize();
            
            return enemyGO;
        }
    }
}