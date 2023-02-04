using UnityEngine;
using UnityEngine.Events;

namespace Src.Models
{
    public class Car : MonoBehaviour
    {
        public int Id;
        public Sprite ShopImage;
        public int Price;
        
        private CarState _state;

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