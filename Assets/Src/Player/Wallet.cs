using Src.Clients;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Player
{
    public class Wallet : MonoBehaviour
    {
        private int _currentMoney = 0;

        public UnityEvent<int> OnMoneyChange;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Money money)) return;
            
            Destroy(money.gameObject);
            _currentMoney += 1;
            OnMoneyChange.Invoke(_currentMoney);
        }
    }
}