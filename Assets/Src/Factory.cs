using System.Collections;
using UnityEngine;

namespace Src
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private float _defaultProductionTimeSpan;
        [SerializeField] private float _productionTimeByLevelReduction = 2f;
        [SerializeField] private Upgrader _upgrader;
        [SerializeField] private Platform _platform;
        [SerializeField] private Product _producableProduct;

        private float _productionTimeSpan;

        private void Start()
        {
            _upgrader.OnUpgrade.AddListener(ApplyUpgrade);
            _platform.OnOutOfSpace.AddListener(StopProduction);
            _platform.OnFreeSpace.AddListener(ContinueProduction);
            
            _productionTimeSpan = _defaultProductionTimeSpan;

            StartCoroutine(LaunchProduction());
        }

        private void OnDisable()
        {
            StopCoroutine(LaunchProduction());
        }

        private void ApplyUpgrade(int level)
        {
            _productionTimeSpan /= _productionTimeByLevelReduction;
        }

        private IEnumerator LaunchProduction()
        {
            yield return new WaitForSeconds(_productionTimeSpan);

            Product newProduct = Instantiate(_producableProduct, transform);
            
            Produce(newProduct);

            yield return LaunchProduction();
        }

        private void StopProduction()
        {
            StopCoroutine(LaunchProduction());
        }

        private void ContinueProduction()
        {
            StartCoroutine(LaunchProduction());
        }

        private void Produce(Product productInstance)
        {
            _platform.Spawn(productInstance);
        }
    }
}