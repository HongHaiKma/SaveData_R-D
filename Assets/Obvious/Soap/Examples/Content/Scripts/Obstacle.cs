using UnityEngine;
using UnityEngine.Events;

namespace Obvious.Soap.Example
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onHitPlayerEvent = null;
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                _onHitPlayerEvent?.Invoke();
        }
    }
}