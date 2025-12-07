using Domain.Entities.Enemy;
using Presentation.Core;
using UnityEngine;

namespace Presentation.Enemies
{
    public class Enemy : MonoBehaviour, IEntityComponentView<EnemyEntity>
    {
        public void Initialize(EnemyEntity context)
        {
            
        }

        public void Cleanup()
        {
            
        }
    }
}