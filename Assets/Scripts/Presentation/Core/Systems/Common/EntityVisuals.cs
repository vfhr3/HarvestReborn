using System.Collections;
using Domain.Entities;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems.Common
{
    public class EntityVisuals : MonoBehaviour, IEntityComponentView<Entity>
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Entity _context;
        private Coroutine _flashCoroutine;
        private bool _isFacingRight = true;
        
        public void Initialize(Entity entity)
        {
            _context = entity;

            spriteRenderer ??= GetComponent<SpriteRenderer>();

            _context.Events.On<DirectionChangedEvent>(Flip);
            _context.Events.On<GracePeriodStartedEvent>(Flash);
        }

        public void Cleanup()
        {
            _context.Events.Off<DirectionChangedEvent>(Flip);
            _context.Events.Off<GracePeriodStartedEvent>(Flash);
        }

        private void Flip(DirectionChangedEvent e)
        {
            Debug.Log("Trying to flip...");
            if (e.Direction.x > 0)
            {
                _isFacingRight = true;
            }
            else if (e.Direction.x < 0)
            {
                _isFacingRight = false;
            }
            spriteRenderer.flipX = !_isFacingRight;
        }

        private IEnumerator FlashCoroutine(float duration, float interval)
        {
            var elapsed = 0f;
            var originalColor = spriteRenderer.color;
            var flashColor = Color.red;

            while (elapsed < duration)
            {
                spriteRenderer.color = flashColor;
                yield return new WaitForSeconds(interval);

                spriteRenderer.color = originalColor;
                yield return new WaitForSeconds(interval);

                elapsed += interval * 2;
            }

            spriteRenderer.color = originalColor;
        }

        private void Flash(GracePeriodStartedEvent eventData)
        {
            if (_flashCoroutine != null) StopCoroutine(_flashCoroutine);

            _flashCoroutine = StartCoroutine(
                FlashCoroutine(eventData.Duration, eventData.Duration / 4)
            );
        }
    }
}