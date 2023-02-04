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

        public Car GetCarById(int id)
        {
            return _cars.Find(car => car.Id == id);
        }

        private void Start()
        {
            _cars.ForEach(car =>
            {
                Instantiate(_carSlot, transform);
                _carSlot.Fill(car);
            });
        }
    }
}