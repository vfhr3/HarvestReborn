using Domain.Components;
using Domain.Container;
using Domain.Entities.Player;
using Infrastructure.Events;
using Presentation.Enemies;
using Presentation.Player;
using Presentation.UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBarPrefab;
        [SerializeField] private PlayerView playerViewPrefab;
        [SerializeField] private Grid terrainPrefab;
        [SerializeField] private Enemy enemyPrefab;

        private PlayerView _playerView;
        private void Awake()
        {
            EntityComponentContainer playerComponents = new EntityComponentContainer();
            var playerEvents = new EventBus();
            playerComponents.Add(new EntityHealthComponent(playerEvents));
            playerComponents.Add(new EntityMovementComponent(playerEvents));
            
            PlayerEntity playerEntity = new PlayerEntity(playerEvents, playerComponents);

            var playerComponentView = Instantiate(playerViewPrefab, Vector3.zero, Quaternion.identity);
            
            playerComponentView.Initialize(playerEntity);
        }

    }
}