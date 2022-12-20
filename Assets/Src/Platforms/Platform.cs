using System;
using System.Collections.Generic;
using System.ComponentModel;
using Src.Base;
using Src.Platforms.PlatformPoint;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Src.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type; 
        [SerializeField] private ProductType _acceptedProductType;
        [SerializeField] private List<PlatformPlace> _places = new();

        private bool _isFull;

        public PlatformType Type => _type;
        public bool IsFull => _isFull;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;
        public UnityEvent OnPlace;

        public void Add(Product product)
        {
            if (product.Type != _acceptedProductType && _acceptedProductType != ProductType.Any)
            {
                throw new WarningException("Product type doesn't match");
            }

            PlatformPlace freePlace = GetFreePlace();

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
            return _places.Find(place => !place.IsOccupied);
        }

        private void Place(Product product, PlatformPlace freePlace)
        {
            Transform productTransform;
            (productTransform = product.transform).SetParent(freePlace.transform);
            productTransform.localPosition = Vector3.zero;
            productTransform.localRotation = Quaternion.identity;
            freePlace.Product = product;
            freePlace.IsOccupied = true;
            OnPlace.Invoke();

            if (!_places.Find(place => !place.IsOccupied))
            {
                _isFull = true;
                OnOutOfSpace.Invoke();
            }
        }
    }
}