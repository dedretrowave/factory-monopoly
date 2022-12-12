using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Player
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _startingMoney;
        private int _currentMoney = 0;

        public int CurrentMoney
        {
            get => _currentMoney;
            private set
            {
                _currentMoney = value;
                OnMoneyChange.Invoke(_currentMoney);
            }
        }

        public UnityEvent<int> OnMoneyChange;

        private void Start()
        {
            CurrentMoney = _startingMoney;
            OnMoneyChange.Invoke(CurrentMoney);
        }

        public void Add(int amount = 1)
        {
            CurrentMoney += amount;
        }

        public void Reduce(int amount = 1)
        {
            int newMoney = CurrentMoney - amount;

            if (newMoney < 0)
            {
                _currentMoney = 0;
                throw new WarningException("Out Of Money");
            }

            CurrentMoney = newMoney;
        }
    }
}