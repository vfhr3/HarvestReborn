using Entities.Player.Data;
using Events.Entity;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        private PlayerContext _playerContext;
        private VisualElement _hpFill;
        
        private float _maxHealth;


        private void Start()
        {

            var ui = GetComponent<UIDocument>().rootVisualElement;
            _hpFill = ui.Q<VisualElement>("health-bar-fill");

            _playerContext.Events.On<HealthChangedEvent>(UpdateValue);

            UpdateValue(_playerContext.Health.Current);

            Debug.Log("Health bar Configured");
        }


        private void OnDestroy()
        {
            _playerContext.Events.Off<HealthChangedEvent>(UpdateValue);
        }

        public void Init(PlayerContext context)
        {
            _playerContext = context;
        }

        private void UpdateValue(float currentHealth)
        {
            var percent = currentHealth / _playerContext.Health.Max;

            _hpFill.style.width = Length.Percent(percent * 100f);
        }

        private void UpdateValue(HealthChangedEvent eventData)
        {
            var percent = (float) eventData.CurrentHealth / _playerContext.Health.Max;
            Debug.Log(percent);
            _hpFill.style.width = Length.Percent(percent * 100f);
        }
    }
}