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

        public Car GetSelectedCar()
        {
            return _cars.Find(car => car.State == CarState.Selected);
        }

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

            _cars.ForEach(car =>
            {
                CarSlotUI newCarSlot = Instantiate(_carSlot, transform);
                newCarSlot.Fill(car);
            });
        }

        private void Clean()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}