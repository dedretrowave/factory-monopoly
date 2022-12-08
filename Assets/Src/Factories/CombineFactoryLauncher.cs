using System;
using System.Collections;
using System.Collections.Generic;
using Src.Base;
using Src.Factories.Base;
using Src.Platforms;
using UnityEngine;

namespace Src.Factories
{
    public class CombineFactoryLauncher : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private Platform _inputPlatform;
        [SerializeField] private Platform _outputPlatform;

        private bool _isPaused;
        private Queue<IEnumerator> _combineQueue = new();
        private Coroutine _queueExecution;

        private void Start()
        {
            _outputPlatform.OnOutOfSpace.AddListener(Pause);
            _outputPlatform.OnFreeSpace.AddListener(Continue);
            _inputPlatform.OnPlace.AddListener(AddToCombineQueue);
        }

        private void AddToCombineQueue()
        {
            _combineQueue.Enqueue(Combine());
            Debug.Log(_combineQueue.Count);

            if (_queueExecution == null)
            {
                _queueExecution = StartCoroutine(ExecuteQueue());
            }
        }

        private IEnumerator ExecuteQueue()
        {
            while (_combineQueue.Count > 0)
            {
                yield return _combineQueue.Dequeue();
            }
            
            StopCoroutine(_queueExecution);
            _queueExecution = null;
        }

        private IEnumerator Combine()
        {
            if (_isPaused) yield return null;
            
            Product product = _inputPlatform.Get();
            Destroy(product.gameObject);
            yield return _factory.ProduceAfterTimeout();
        }

        private void Pause()
        {
            StopCoroutine(_queueExecution);
        }

        private void Continue()
        {
            _queueExecution = StartCoroutine(ExecuteQueue());
        }
    }
}