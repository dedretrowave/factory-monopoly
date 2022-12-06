using System.Collections;
using Src.Base;
using Src.Platforms;
using UnityEngine;

namespace Src.Leveling
{
    public class UpgradeSpot : MonoBehaviour
    {
        [SerializeField] private Platform _platform;
        [SerializeField] private float _costOfUpgrade;
        [SerializeField] private Level _level;

        private float _moneyTransferred;

        private void Start()
        {
            _platform.OnPlace.AddListener(Upgrade);
            _level.OnMaxLevelReached.AddListener(Remove);
        }

        private void Remove()
        {
            Destroy(gameObject);
        }

        private void Upgrade()
        {
            Product product = _platform.Get();
            Destroy(product.gameObject);

            _moneyTransferred++;

            if (_moneyTransferred >= _costOfUpgrade)
            {
                _level.Upgrade();
                _costOfUpgrade *= 1.5f;
                _moneyTransferred = 0f;
            }
        }
    }
}