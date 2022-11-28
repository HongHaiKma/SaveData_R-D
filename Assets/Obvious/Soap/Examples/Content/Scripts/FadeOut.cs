using System.Collections;
using UnityEngine;

namespace Obvious.Soap.Example
{
    public class FadeOut : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private CanvasGroup _canvasGroup = null;

        private Coroutine _coroutine = null;

        public void Activate()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Cr_FadeOut());
        }

        private IEnumerator Cr_FadeOut()
        {
            float timer = 0f;
            _canvasGroup.alpha = 1f;
            while (timer <= _duration)
            {
                _canvasGroup.alpha =  Mathf.Lerp(1f,0f,timer/_duration);
                timer += Time.deltaTime;
                yield return null;
            }

            _canvasGroup.alpha = 0;
        }
    }
}