using System.ComponentModel;
using Src.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Player
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _startingMoney;
        private int _currentMoney = 0;

        public UnityEvent<int> OnMoneyChange;

        private void Start()
        {
            _currentMoney = _startingMoney;
        }

        public void Add(int amount = 1)
        {
            _currentMoney += amount;
            OnMoneyChange.Invoke(_currentMoney);
        }

        public void Reduce(int amount = 1)
        {
            int newMoney = _currentMoney - amount;

            if (newMoney < 0)
            {
                _currentMoney = 0;
                OnMoneyChange.Invoke(_currentMoney);
                throw new WarningException("Out Of Money");
            }

            _currentMoney = newMoney;
            OnMoneyChange.Invoke(_currentMoney);
        }
    }
}