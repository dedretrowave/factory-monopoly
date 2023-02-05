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

        public void Load()
        {
            Clean();
            
            _cars.ForEach(car =>
            {
                Debug.Log(car);
                Instantiate(_carSlot, transform);
                _carSlot.Fill(car);
            });
        }

        private void Clean()
        {
            foreach (var child in transform)
            {
                Destroy(child as GameObject);
            }
        }
    }
}