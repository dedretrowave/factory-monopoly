using System.Collections;
using System.ComponentModel;
using Src.Base;
using Src.Leveling;
using Src.Platforms;
using Src.Platforms.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src.Factories.Base
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private float _defaultProductionTimeSpan;
        [SerializeField] private float _productionTimeByLevelReduction = 2f;
        [SerializeField] private Level _level;
        [SerializeField] private Platform _outputPlatform;
        [SerializeField] private Product _producableProduct;

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
            Product newProduct = Instantiate(_producableProduct, transform);

            _outputPlatform.Add(newProduct);
        }
    }
}