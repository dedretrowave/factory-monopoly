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
                
                car.OnPurchased.AddListener(CompletePurchase);
                car.OnSelected.AddListener(CompleteSelect);
            });
        }

        private void CompletePurchase(Car car)
        {
            _wallet.Reduce(car.Price);
            //TODO: SAVE CAR PURCHASE
        }

        private void CompleteSelect(Car car)
        {
            _loader.LoadNew(car);
        }
    }
}