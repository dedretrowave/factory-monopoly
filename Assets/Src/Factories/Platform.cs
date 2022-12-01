using System.Collections.Generic;
using Src.Factories.PlatformPoint;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Factories
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type;
        [SerializeField] private List<PlatformPlace> _places = new();
        private bool _isFull;

        public PlatformType Type => _type;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;

        public void AddProduct(Product product)
        {
            PlatformPlace freePoint = _places.Find(place => !place.IsOccupied);

            if (freePoint == null)
            {
                _isFull = true;
                OnOutOfSpace.Invoke();
                Destroy(product.gameObject);
                return;
            }

            product.transform.SetParent(freePoint.transform);
            product.transform.localPosition = Vector3.zero;
            freePoint.Product = product;
            freePoint.IsOccupied = true;
        }

        public Product GetProduct()
        {
            PlatformPlace place = _places.Find(place => place.IsOccupied);

            if (place == null) return null;

            Product product = place.Product;

            place.Product = null;
            place.IsOccupied = false;

            if (_isFull)
            {
                OnFreeSpace.Invoke();
                _isFull = false;
            }

            return product;
        }
    }
}