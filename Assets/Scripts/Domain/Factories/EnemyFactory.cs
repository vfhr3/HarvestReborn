using Presentation.Enemies;
using UnityEngine;

namespace Domain.Factories
{
    public static class EnemyFactory
    {
        public static Enemy Create(Vector3 spawnPosition)
        {
            var enemyGO = Object.Instantiate(Resources.Load<Enemy>("Enemy/Enemy"), spawnPosition, Quaternion.identity);
            
            
            return enemyGO;
        }
    }
}