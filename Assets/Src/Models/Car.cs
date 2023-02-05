using UnityEngine;
using UnityEngine.Events;

namespace Src.Models
{
    [CreateAssetMenu(fileName = "Car", menuName = "Car", order = 0)]
    public class Car : ScriptableObject
    {
        public int Id;
        public Sprite ShopImage;
        public int Price;
        public Transform Prefab;

        [SerializeField] private CarState _state = CarState.OnSale;

        public CarState State
        {
            get => _state;
            set
            {
                OnStateChange.Invoke(this);
                _state = value;
            }
        }

        public UnityEvent<Car> OnStateChange;
    }

    public enum CarState
    {
        OnSale,
        Purchased,
        Selected
    }
}