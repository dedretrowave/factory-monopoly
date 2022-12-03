using System.Collections.Generic;
using Src.Factories.PlatformPoint;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Factories
{
    public class ProductPlatform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type;
        [SerializeField] private List<PlatformPlace> _places = new();
        private bool _isFull;

        public PlatformType Type => _type;
        public bool IsFull => _isFull;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;

        public void Spawn(Product productPrefab)
        {
            Product newProduct = Instantiate(productPrefab, transform);

            PlatformPlace freePlace = GetFreePlace();

            if (freePlace == null)
            {
                Destroy(newProduct.gameObject);
                return;
            }

            Place(newProduct, freePlace);
        }

        public void Add(Product product)
        {
            PlatformPlace freePlace = GetFreePlace();

            if (freePlace == null) return;
            
            Place(product, freePlace);
        }

        public Product Get()
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

        private PlatformPlace GetFreePlace()
        {
            PlatformPlace freePoint = _places.Find(place => !place.IsOccupied);

            if (freePoint == null)
            {
                _isFull = true;
                OnOutOfSpace.Invoke();
                return null;
            }

            return freePoint;
        }

        private void Place(Product product, PlatformPlace freePlace)
        {
            product.transform.SetParent(freePlace.transform);
            product.transform.localPosition = Vector3.zero;
            freePlace.Product = product;
            freePlace.IsOccupied = true;
        }
    }
}