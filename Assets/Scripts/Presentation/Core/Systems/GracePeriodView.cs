using System.Collections;
using Domain.Events.Entity;
using UnityEngine;

namespace Presentation.Core.Systems
{
    public class GracePeriodView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Coroutine _flashCoroutine;
        
        
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