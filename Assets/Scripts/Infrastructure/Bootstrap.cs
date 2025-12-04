using Entities.Enemies;
using Entities.Player;
using Infrastructure.Factories;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Grid terrainPrefab;
        [SerializeField] private Enemy enemyPrefab;

        private Player _player;
        private void Awake()
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            _player = player;
        }

        [ContextMenu("Create Enemy")]
        private void CreateEnemy()
        {
            var enemy = EnemyFactory.Create(new Vector3(0, 5, 0));
        }
    }
}