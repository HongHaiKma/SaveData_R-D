using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Obvious.Soap
{
    [System.Serializable]
    public abstract class ScriptableEvent<T> : ScriptableEventBase, IDrawObjectsInInspector
    {
        [SerializeField] private bool _debugLogEnabled = false;
        [SerializeField] protected T _debugValue = default(T);

        private readonly List<EventListenerGeneric<T>> _eventListeners = new List<EventListenerGeneric<T>>();
        private readonly List<Object> _listenersObjects = new List<Object>();
        private Action<T> _onRaised = null;

        public event Action<T> OnRaised
        {
            add
            {
                _onRaised += value;

                var listener = value.Target as Object;
                if (listener != null && !_listenersObjects.Contains(listener))
                    _listenersObjects.Add(listener);
            }
            remove
            {
                _onRaised -= value;

                var listener = value.Target as Object;
                if (_listenersObjects.Contains(listener))
                    _listenersObjects.Remove(listener);
            }
        }

        public void Raise(T param)
        {
            if (!Application.isPlaying)
                return;

            for (var i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(this, param, _debugLogEnabled);

            _onRaised?.Invoke(param);
        }

        public void RegisterListener(EventListenerGeneric<T> listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(EventListenerGeneric<T> listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }

        public List<Object> GetAllObjects()
        {
            var allObjects = new List<Object>(_eventListeners);
            allObjects.AddRange(_listenersObjects);
            return allObjects;
        }
    }
}