using System;
using Infrastructure;
using UnityEngine;

namespace _Domain._Services.Time
{
    public class RecoveryTimer : ITimer
    {
        private readonly float _baseDuration;

        private readonly Action _onComplete;

        private float _cdr;
        private float _currentDuration;

        public RecoveryTimer(float baseDuration, float initialCdr = 0f, Action onComplete = null)
        {
            _baseDuration = Mathf.Max(GameConstants.MinCooldown, baseDuration);
            _cdr = Mathf.Max(0, initialCdr);


            RecalculateDuration();
            TimeLeft = _currentDuration;
            _onComplete = onComplete;
        }

        public bool IsRunning { get; private set; }

        public float TimeLeft { get; private set; }

        public float Progress => 1f - TimeLeft / _currentDuration;

        public void Start()
        {
            IsRunning = true;
            TimeLeft = _currentDuration;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Update(float deltaTime)
        {
            if (!IsRunning) return;

            TimeLeft -= deltaTime;

            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                IsRunning = false;
                _onComplete?.Invoke();
            }
        }

        public void SetCdr(float newValue)
        {
            newValue = Mathf.Max(GameConstants.MinCooldownRecoveryRate, newValue);
            if (Mathf.Abs(newValue - _cdr) < 0.0001f) return;

            var oldProgress = Progress;

            _cdr = newValue;
            RecalculateDuration();

            TimeLeft = _currentDuration * (1f - oldProgress);
        }

        private void RecalculateDuration()
        {
            _currentDuration = _baseDuration / (1f + _cdr);
            _currentDuration = Mathf.Max(GameConstants.MinCooldown, _currentDuration);
        }
    }
}