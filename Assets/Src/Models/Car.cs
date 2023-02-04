using System;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Models
{
    [Serializable]
    public class Car
    {
        public string Name;
        public Sprite ShopImage;
        public int Price;
        public Transform Prefab;
        
        private CarState _state;

        public Car(Car car)
        {
            Name = car.Name;
            ShopImage = car.ShopImage;
            Price = car.Price;
            State = car.State;
        }

        public CarState State
        {
            get => _state;
            set
            {
                _state = value;
                OnStateChange.Invoke(this);
            }
        }

        public UnityEvent<Car> OnStateChange;
    }
    
    public enum CarState
    {
        OnSale,
        Purchased,
        Selected,
    }
}