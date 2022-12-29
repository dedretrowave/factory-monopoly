using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Src.Factories.Base;
using Src.Misc;
using Src.Platforms;
using UnityEngine;

namespace Src.Factories
{
    public class CombineFactoryLauncher : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private Platform _inputPlatform;
        [SerializeField] private Platform _outputPlatform;

        private ExecutionQueue _executionQueue;

        private void Start()
        {
            _executionQueue = gameObject.AddComponent<ExecutionQueue>();
            _outputPlatform.OnOutOfSpace.AddListener(_executionQueue.Pause);
            _outputPlatform.OnFreeSpace.AddListener(_executionQueue.Continue);
            _inputPlatform.OnPlace.AddListener(() => _executionQueue.Add(Combine()));
        }

        private IEnumerator Combine()
        {
            Product.Product product = _inputPlatform.Get();
            DOTween.Sequence()
                .Append(product.transform.DOMove(transform.position, GlobalSettings.TWEEN_DURATION))
                .AppendCallback(() => Destroy(product.gameObject));

            yield return _factory.ProduceAfterTimeout();
        }
    }
}