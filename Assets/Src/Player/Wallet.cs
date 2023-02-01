using System;
using DI;
using Src.Save;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Player
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int _startingMoney;
        private int _currentMoney = -10;

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
            DependencyContext.Dependencies.Add(new Dependency( typeof(Wallet), () => this));
            
            int moneyFromSave = SaveSystem.Instance.GetMoney();

            if (moneyFromSave < 0)
            {
                _currentMoney = _startingMoney;
            }
            else
            {
                _currentMoney = moneyFromSave;
            }
            
            OnMoneyChange.Invoke(CurrentMoney);
        }

        public void Add(int amount = 1)
        {
            CurrentMoney += amount;
            
            SaveSystem.Instance.SaveMoney(CurrentMoney);
        }

        public void Reduce(int amount = 1)
        {
            int newMoney = CurrentMoney - amount;

            if (newMoney < 0)
            {
                _currentMoney = 0;
                throw new Exception("Out Of Money");
            }

            CurrentMoney = newMoney;
            
            SaveSystem.Instance.SaveMoney(CurrentMoney);
        }
    }
}