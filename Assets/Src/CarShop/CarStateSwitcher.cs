using System;
using DI;
using Src.Models;
using Src.Player;
using UnityEngine;

namespace Src.CarShop
{
    public class CarStateSwitcher : MonoBehaviour
    {
        [SerializeField] private CarLoader _loader;
        [SerializeField] private Wallet _wallet;

        [SerializeField] private CarShop _shop;

        private void Start()
        {
            DependencyContext.Dependencies.Add(new Dependency(typeof(CarStateSwitcher), () => this));
        }

        public void SwitchToPurchased(int carId)
        {
            Car car = _shop.GetCarById(carId);
            
            SwitchToPurchased(car);
        }

        public void SwitchToSelected(int carId)
        {
            Car car = _shop.GetCarById(carId);
            
            Debug.Log($"FOUND IN SHOP: {car}");
            
            SwitchToSelected(car);
        }
        
        private void SwitchToPurchased(Car car)
        {
            Debug.Log($"PURCHASED CAR: ${car.Id}");

            return;
            
            
            try
            {
                _wallet.Reduce(car.Price);
            }
            catch (Exception e)
            {
                car.State = CarState.OnSale;
                throw;
            }

            car.State = CarState.Purchased;
        }

        private void SwitchToSelected(Car car)
        {
            Debug.Log($"PURCHASED CAR: ${car.Id}");

            return;
            
            _loader.LoadNew(car);
            car.State = CarState.Selected;
        }
    }
}