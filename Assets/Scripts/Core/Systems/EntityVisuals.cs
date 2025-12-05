using System.Collections;
using Abstractions;
using Core.Entity;
using Events.Entity;
using UnityEngine;

namespace Core.Systems
{
    public class EntityVisuals : ContextDrivenComponent<EntityContext>
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private EntityContext _context;
        private Coroutine _flashCoroutine;

        private void OnDestroy()
        {
            _context.Events.Off<DirectionChangedEvent>(Flip);
            _context.Events.Off<GracePeriodStartedEvent>(Flash);
        }

        public override void Initialize(EntityContext context)
        {
            _context = context;

            spriteRenderer ??= GetComponent<SpriteRenderer>();

            _context.Events.On<DirectionChangedEvent>(Flip);
            _context.Events.On<GracePeriodStartedEvent>(Flash);
        }

        private void Flip(DirectionChangedEvent e)
        {
            spriteRenderer.flipX = !e.IsFacingRight;
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