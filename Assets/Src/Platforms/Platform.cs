using System.Collections.Generic;
using System.ComponentModel;
using Src.Base;
using Src.Platforms.PlatformPoint;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type;
        [SerializeField] private List<PlatformPlace> _places = new();

        private bool _isFull;

        public PlatformType Type => _type;
        public bool IsFull => _isFull;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;
        public UnityEvent OnPlace;

        public void Add(Product product)
        {
            PlatformPlace freePlace = GetFreePlace();

            if (freePlace == null)
            {
                throw new WarningException("No Free Place");
            }
            
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
            OnPlace.Invoke();
        }
    }
}