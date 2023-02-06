using System;
using DI;
using Src.Models;
using Src.Player;
using UnityEngine;

namespace Src.CarShop
{
    public class CarStateSwitcher : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private CarLoader _loader;
        [SerializeField] private CarShop _shop;
        
        private void Start()
        {
            DependencyContext.Dependencies.Add(new Dependency(typeof(CarStateSwitcher), () => this));
            _shop.Load();
        }

        public void Purchase(Car car)
        {
            try
            {
                _wallet.Reduce(car.Price);
                car.State = CarState.Purchased;
                _shop.Load();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                throw;
            }
        }

        public void Select(Car car)
        {
            _loader.LoadNew(car);
            _shop.MarkSelected(car);
            _shop.Load();
        }
    }
}