using Domain.Components;
using Domain.Events.Entity;
using Domain.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation.UI
{
    public class HealthBar : MonoBehaviour
    {
        private IHealthComponent _context;
        private VisualElement _hpFill;
        
        private float _maxHealth;


        private void Start()
        {

            var ui = GetComponent<UIDocument>().rootVisualElement;
            _hpFill = ui.Q<VisualElement>("health-bar-fill");

            _context.Events.On<HealthChangedEvent>(UpdateValue);

            UpdateValue(_context.Current);

            Debug.Log("Health bar Configured");
        }


        private void OnDestroy()
        {
            _context.Events.Off<HealthChangedEvent>(UpdateValue);
        }

        public void Init(IHealthComponent context)
        {
            _context = context;
        }

        private void UpdateValue(float currentHealth)
        {
            var percent = currentHealth / _context.Max;

            _hpFill.style.width = Length.Percent(percent * 100f);
        }

        private void UpdateValue(HealthChangedEvent eventData)
        {
            var percent = eventData.Percent;
            Debug.Log(percent);
            _hpFill.style.width = Length.Percent(percent * 100f);
        }
    }
}