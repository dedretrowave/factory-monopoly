using System;
using System.Collections.Generic;
using Src.Models;
using Src.Player;
using Src.UI.CarShop;
using UnityEngine;

namespace Src.CarShop
{
    public class CarShop : MonoBehaviour
    {
        [SerializeField] private CarLoader _loader;
        [SerializeField] private Wallet _wallet;
        
        [SerializeField] private List<Car> _cars;
        [SerializeField] private CarSlotUI _carSlot;

        private void Start()
        {
            _cars.ForEach(car =>
            {
                Instantiate(_carSlot, transform);
                _carSlot.Fill(car);
                
                car.OnStateChange.AddListener(CompleteCarStateTransition);
            });
        }

        private void CompleteCarStateTransition(Car car)
        {
            switch (car.State)
            {
                case CarState.OnSale:
                    break;
                case CarState.Purchased:
                    CompletePurchase(car);
                    break;
                case CarState.Selected:
                    // CompleteSelect(car);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            _carSlot.Fill(car);
        }

        private void CompletePurchase(Car car)
        {
            try
            {
                _wallet.Reduce(car.Price);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                car.State = CarState.OnSale;
                throw;
            }
        }

        private void CompleteSelect(Car car)
        {
            _loader.LoadNew(car);
        }
    }
}