using Domain.Factories;
using Infrastructure.Configs;
using Infrastructure.Factories;
using Presentation.Enemies;
using Presentation.UI;
using UnityEngine;
using Player = Domain.Entities.Player.Player;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBarPrefab;
        [SerializeField] private Presentation.Player.Player playerPrefab;
        [SerializeField] private Grid terrainPrefab;
        [SerializeField] private Enemy enemyPrefab;

        private Presentation.Player.Player _player;
        private void Awake()
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            var playerEntity = player.GetComponent<Presentation.Player.Player>();
            var playerConfig = new PlayerConfig()
            {
                GracePeriodDuration = 0.3f,
                MaxHealth = 100,
                Speed = 5
            };
            playerEntity.Initialize(new ContextFactory<Player>().From(playerConfig, new Vector2(0, 0)));
            
            var healthBar = Instantiate(healthBarPrefab, Vector3.zero, Quaternion.identity);
            healthBar.Init(playerEntity.Context);
            
            Destroy(gameObject);
        }

        [ContextMenu("Create Enemy")]
        private void CreateEnemy()
        {
            EnemyFactory.Create(new Vector3(0, 5, 0));
        }
    }
}