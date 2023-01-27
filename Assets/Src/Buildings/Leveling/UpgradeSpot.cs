using System;
using Src.Buildings.Platforms;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Buildings.Leveling
{
    public class UpgradeSpot : MonoBehaviour
    {
        [SerializeField] private Platform _platform;
        [SerializeField] private int _costOfUpgrade;
        [SerializeField] private float _riseOfUpgradeCost = 1.5f;
        [SerializeField] private Level _level;

        private float _moneyTransferred;

        [HideInInspector] public UnityEvent<float> OnPriceChange;

        public float CostOfUpgrade => _costOfUpgrade;

        private void Start()
        {
            _platform.OnPlace.AddListener(Upgrade);
            _level.OnMaxLevelReached.AddListener(Remove);
            _level.OnUpgrade.AddListener(IncreasePrice);
            OnPriceChange.Invoke(_costOfUpgrade);
        }

        private void Remove()
        {
            Debug.Log($"{_level.Id} : Level maxed");
            gameObject.SetActive(false);
        }

        private void Upgrade()
        {
            Product.Product product = _platform.Get();
            Destroy(product.gameObject);

            _moneyTransferred++;

            if (_moneyTransferred >= _costOfUpgrade)
            {
                _level.Upgrade();
                return;
            }
            
            OnPriceChange.Invoke(_costOfUpgrade - _moneyTransferred);
        }

        private void IncreasePrice()
        {
            _costOfUpgrade = Mathf.RoundToInt(_costOfUpgrade * _riseOfUpgradeCost);
            _moneyTransferred = 0f;
            OnPriceChange.Invoke(_costOfUpgrade - _moneyTransferred);
        }
    }
}