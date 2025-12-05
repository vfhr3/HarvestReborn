using Entities.Enemies;
using Entities.Player;
using Entities.Player.Data;
using Infrastructure.Factories;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBarPrefab;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Grid terrainPrefab;
        [SerializeField] private Enemy enemyPrefab;

        private Player _player;
        private void Awake()
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            var playerEntity = player.GetComponent<Player>();
            var playerConfig = new PlayerConfig()
            {
                GracePeriodDuration = 0.3f,
                MaxHealth = 100,
                Speed = 5
            };
            playerEntity.Initialize(new ContextFactory<PlayerContext>().From(playerConfig, new Vector2(0, 0)));
            
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