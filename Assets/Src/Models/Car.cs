using UnityEngine;
using UnityEngine.Events;

namespace Src.Models
{
    public class Car : MonoBehaviour
    {
        public string Name;
        public Sprite ShopImage;
        public int Price;
        public Transform Prefab;
        
        private bool _isPurchased;
        private bool _isSelected;

        public bool IsPurchased
        {
            get => _isPurchased;
            set
            {
                if (!value) return;
                
                OnPurchased.Invoke(this);
                _isPurchased = value;
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (!value) return;
                
                OnSelected.Invoke(this);
                _isSelected = value;
            }
        }

        public UnityEvent<Car> OnPurchased;
        public UnityEvent<Car> OnSelected;
    }
}