using Domain.Components;
using Domain.Components.Common;
using Domain.Container;
using Domain.Entities.Player;
using Infrastructure.Components;
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
            var playerComponentView = Instantiate(playerViewPrefab, Vector3.zero, Quaternion.identity);
            
            var playerEvents = new EventBus();
            EntityComponentContainer playerComponents = new EntityComponentContainer();
            playerComponents.Add(new EntityHealthComponent(playerEvents));
            playerComponents.Add(new TransformBasedMovementComponent(
                playerEvents,
                new UnityTransformProvider(playerComponentView.transform),
                5));
            PlayerEntity playerEntity = new PlayerEntity(playerEvents, playerComponents);
            

            
            playerComponentView.Initialize(playerEntity);
        }

    }
}