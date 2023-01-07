using System.Collections;
using Src.Buildings.Leveling;
using Src.Buildings.Platforms;
using UnityEngine;

namespace Src.Buildings.Factories.Base
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private float _defaultProductionTimeSpan;
        [SerializeField] private float _productionTimeByLevelReduction = 2f;
        [SerializeField] private Level _level;
        [SerializeField] private Platform _outputPlatform;
        [SerializeField] private Product.Product _producableProduct;

        private float _productionTimeSpan;
        private Coroutine _productionCoroutine;

        private void Start()
        {
            _level.OnUpgrade.AddListener(Upgrade);
            
            _productionTimeSpan = _defaultProductionTimeSpan;
        }

        private void Upgrade()
        {
            _productionTimeSpan /= _productionTimeByLevelReduction;
        }

        public IEnumerator ProduceAfterTimeout()
        {
            yield return new WaitForSeconds(_productionTimeSpan);
            
            Produce();
        }

        private void Produce()
        {
            Product.Product newProduct = Instantiate(_producableProduct, transform);

            _outputPlatform.Add(newProduct);
        }
    }
}