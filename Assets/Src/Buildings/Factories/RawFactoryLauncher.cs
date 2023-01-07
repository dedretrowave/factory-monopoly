using System.Collections;
using Src.Buildings.Factories.Base;
using Src.Buildings.Platforms;
using UnityEngine;

namespace Src.Buildings.Factories
{
    public class RawFactoryLauncher : MonoBehaviour
    {
        [SerializeField] private Factory _factory;
        [SerializeField] private Platform _outputPlatform;

        private Coroutine _productionCorooutine;
        
        private void Start()
        {
            _outputPlatform.OnOutOfSpace.AddListener(StopProduction);
            _outputPlatform.OnFreeSpace.AddListener(ContinueProduction);

            _productionCorooutine = StartCoroutine(LaunchContinuousProduction());
        }

        private IEnumerator LaunchContinuousProduction()
        {
            while (true)
            {
                yield return _factory.ProduceAfterTimeout();
            }
        }

        private void StopProduction()
        {
            StopCoroutine(_productionCorooutine);
        }

        private void ContinueProduction()
        {
            _productionCorooutine = StartCoroutine(LaunchContinuousProduction());
        }
    }
}