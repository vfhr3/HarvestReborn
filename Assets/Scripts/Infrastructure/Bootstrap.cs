using Presentation.Enemies;
using Presentation.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBarPrefab;
        [FormerlySerializedAs("playerPrefab")] [SerializeField] private Presentation.Player.PlayerView playerViewPrefab;
        [SerializeField] private Grid terrainPrefab;
        [SerializeField] private Enemy enemyPrefab;

        private Presentation.Player.PlayerView _playerView;
        private void Awake()
        {

        }

    }
}