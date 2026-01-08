using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Tools
{
    public class GameObjectDisposer : IDisposable
    {
        private GameObject _gameObject;

        public GameObjectDisposer(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObjectDisposer(Component monoBehaviour)
        {
            _gameObject = monoBehaviour.gameObject;
        }

        public void Dispose()
        {
            if (_gameObject != null)
            {
                Object.Destroy(_gameObject);
                _gameObject = null;
            }
        }
    }
}