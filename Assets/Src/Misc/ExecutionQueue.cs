using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Misc
{
    public class ExecutionQueue : MonoBehaviour
    {
        private Queue<IEnumerator> _queue = new();
        private Coroutine _queueExecution;

        public void Add(IEnumerator func)
        {
            Debug.Log("NEW ITEM!");
            _queue.Enqueue(func);

            if (_queueExecution == null)
            {
                _queueExecution = StartCoroutine(ExecuteQueue());
            }
        }

        private IEnumerator ExecuteQueue()
        {
            while (_queue.Count > 0)
            {
                Debug.Log("QUEUE TICK");
                yield return _queue.Dequeue();
            }

            StopCoroutine(_queueExecution);
            _queueExecution = null;
        }

        public void Pause()
        {
            Debug.Log("PAUSE");
            StopCoroutine(_queueExecution);
        }

        public void Continue()
        {
            Debug.Log("CONTINUE");
            _queueExecution = StartCoroutine(ExecuteQueue());
        }
    }
}