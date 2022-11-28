using NUnit.Framework;
using UnityEngine;

namespace Obvious.Soap.Tests
{
    public class ScriptableListTest
    {
        private ScriptableListGameObject _gameObjectScriptableList = null;

        [SetUp]
        public void SetUp()
        {
            _gameObjectScriptableList = ScriptableObject.CreateInstance<ScriptableListGameObject>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_gameObjectScriptableList);
        }

        [Test]
        public void OnItemAddedEvent()
        {
            _gameObjectScriptableList.Reset();
            var eventCalledCount = 0;
            _gameObjectScriptableList.OnItemAdded += (go) => eventCalledCount++;

            for (int i = 0; i < 5; i++)
            {
                var go = new GameObject($"GameObject{i}");
                _gameObjectScriptableList.Add(go);
            }

            Assert.AreEqual(5, eventCalledCount);
        }

        [Test]
        public void OnItemRemoveEvent()
        {
            _gameObjectScriptableList.Reset();
            for (int i = 0; i < 5; i++)
            {
                var go = new GameObject($"GameObject{i}");
                _gameObjectScriptableList.Add(go);
            }

            var eventCalledCount = 5;
            _gameObjectScriptableList.OnItemRemoved += (go) => eventCalledCount--;

            for (int i = _gameObjectScriptableList.Count - 1; i >= 0; i--)
            {
                var go = _gameObjectScriptableList[i];
                _gameObjectScriptableList.Remove(go);
            }

            Assert.AreEqual(0, eventCalledCount);
        }

        [Test]
        public void OnItemCountChangeEvent()
        {
            _gameObjectScriptableList.Reset();

            var eventCalledCount = 0;
            _gameObjectScriptableList.OnItemCountChanged += (go) => eventCalledCount++;

            for (int i = 0; i < 5; i++)
            {
                var go = new GameObject($"GameObject{i}");
                _gameObjectScriptableList.Add(go);
            }

            for (int i = _gameObjectScriptableList.Count - 1; i >= 0; i--)
            {
                var go = _gameObjectScriptableList[i];
                _gameObjectScriptableList.Remove(go);
            }

            Assert.AreEqual(10, eventCalledCount);
            Assert.AreEqual(0, _gameObjectScriptableList.Count);
        }

        [Test]
        public void OnClearEvent()
        {
            _gameObjectScriptableList.Reset();
            for (int i = 0; i < 5; i++)
            {
                var go = new GameObject($"GameObject{i}");
                _gameObjectScriptableList.Add(go);
            }
            var itemCount = _gameObjectScriptableList.Count;
            
            _gameObjectScriptableList.OnCleared += () => itemCount = _gameObjectScriptableList.Count;
            _gameObjectScriptableList.Reset();
            
            Assert.AreEqual(0, itemCount);
        }
    }
}