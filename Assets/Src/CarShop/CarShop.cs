using System.Collections.Generic;
using Src.Models;
using Src.UI.CarShop;
using UnityEngine;

namespace Src.CarShop
{
    public class CarShop : MonoBehaviour
    {
        [SerializeField] private List<Car> _cars;
        [SerializeField] private CarSlotUI _carSlot;

        public void MarkSelected(Car selectedCar)
        {
            _cars.ForEach(car =>
            {
                if (car.State == CarState.Selected)
                {
                    car.State = CarState.Purchased;
                }
                
                if (car.Id == selectedCar.Id && selectedCar.State == CarState.Purchased)
                {
                    car.State = CarState.Selected;
                }
            });
        }

        public void Load()
        {
            Clean();
            
            Debug.Log("LOADING");
            
            _cars.ForEach(car =>
            {
                Debug.Log($"LOADED: CAR {car.Id}: {car.State}");
                CarSlotUI newCarSlot = Instantiate(_carSlot, transform);
                newCarSlot.Fill(car);
            });
            
            Debug.Log("LOADED");
        }

        private void Clean()
        {
            Debug.Log("DESTROYING");
            foreach (Transform child in transform)
            {
                Debug.Log($"{child.name}");
                Destroy(child.gameObject);
            }
            
            Debug.Log("DESTROYED");
        }
    }
}