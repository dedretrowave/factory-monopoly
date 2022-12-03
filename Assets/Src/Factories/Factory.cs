using System.Collections;
using Src.Factories.Leveling;
using UnityEngine;

namespace Src.Factories
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private float _defaultProductionTimeSpan;
        [SerializeField] private float _productionTimeByLevelReduction = 2f;
        [SerializeField] private Upgrader _upgrader;
        [SerializeField] private ProductPlatform _platform;
        [SerializeField] private Product _producableProduct;

        private float _productionTimeSpan;
        private Coroutine _productionCoroutine;

        private void Start()
        {
            _upgrader.OnUpgrade.AddListener(ApplyUpgrade);
            _platform.OnOutOfSpace.AddListener(StopProduction);
            _platform.OnFreeSpace.AddListener(ContinueProduction);
            
            _productionTimeSpan = _defaultProductionTimeSpan;
            _productionCoroutine = StartCoroutine(LaunchProduction());
        }

        private void OnDisable()
        {
            StopCoroutine(_productionCoroutine);
        }

        private void ApplyUpgrade(int level)
        {
            _productionTimeSpan /= _productionTimeByLevelReduction;
        }

        private IEnumerator LaunchProduction()
        {
            while (true)
            {
                yield return new WaitForSeconds(_productionTimeSpan);
            
                Produce();
            }
        }

        private void StopProduction()
        {
            StopCoroutine(_productionCoroutine);
        }

        private void ContinueProduction()
        {
            _productionCoroutine = StartCoroutine(LaunchProduction());
        }

        private void Produce()
        {
            _platform.Spawn(_producableProduct);
        }
    }
}