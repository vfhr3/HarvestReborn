using Domain.Events.Entity;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.UI
{
    public class HealthBar : MonoBehaviour
    {
        private Domain.Entities.Player.Player _player;
        private VisualElement _hpFill;
        
        private float _maxHealth;


        private void Start()
        {

            var ui = GetComponent<UIDocument>().rootVisualElement;
            _hpFill = ui.Q<VisualElement>("health-bar-fill");

            _player.Events.On<HealthChangedEvent>(UpdateValue);

            UpdateValue(_player.Health.Current);

            Debug.Log("Health bar Configured");
        }


        private void OnDestroy()
        {
            _player.Events.Off<HealthChangedEvent>(UpdateValue);
        }

        public void Init(Domain.Entities.Player.Player context)
        {
            _player = context;
        }

        private void UpdateValue(float currentHealth)
        {
            var percent = currentHealth / _player.Health.Max;

            _hpFill.style.width = Length.Percent(percent * 100f);
        }

        private void UpdateValue(HealthChangedEvent eventData)
        {
            var percent = (float) eventData.CurrentHealth / _player.Health.Max;
            Debug.Log(percent);
            _hpFill.style.width = Length.Percent(percent * 100f);
        }
    }
}