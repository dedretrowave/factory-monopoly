using System.Collections;
using DG.Tweening;
using Src.Buildings.Factories.Base;
using Src.Buildings.Platforms;
using Src.Helpers;
using UnityEngine;

namespace Src.Buildings.Factories
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