using Src.Save;
using UnityEngine;

namespace Src.Buildings.Platforms
{
    public class StartingMoneyPlatform : MonoBehaviour
    {
        [SerializeField] private int _startingMoney;
        [SerializeField] private Product.Product _money;
        [SerializeField] private Platform _platform;

        private bool _isCollected;

        private void Start()
        {
            _isCollected = SaveSystem.Instance.GetIsStartingCollected();

            if (_isCollected)
            {
                Remove();
                return;
            }
            
            _platform.OnOutOfSpace.AddListener(Remove);

            for (int i = 0; i < _startingMoney; i++)
            {
                Product.Product money = Instantiate(_money, transform);
                _platform.Add(money);
            }
        }

        private void Remove()
        {
            Destroy(gameObject);
        }
    }
}