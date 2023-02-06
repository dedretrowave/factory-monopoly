using System;
using System.Collections.Generic;
using DG.Tweening;
using Src.Buildings.Platforms.PlatformPlace;
using Src.Helpers;
using Src.Product;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Buildings.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type; 
        [SerializeField] private ProductType _acceptedProductType;
        [SerializeField] private List<Buildings.Platforms.PlatformPlace.PlatformPlace> _places = new();

        private bool _isFull;

        public PlatformType Type => _type;
        public bool IsFull => _isFull;
        
        [HideInInspector]
        public UnityEvent OnOutOfSpace;
        [HideInInspector]
        public UnityEvent OnFreeSpace;
        [HideInInspector]
        public UnityEvent OnPlace;

        public void Add(Product.Product product)
        {
            if (_isFull) return;
            
            if (product.Type != _acceptedProductType && _acceptedProductType != ProductType.Any)
            {
                throw new Exception("Product type doesn't match");
            }

            var freePlace = GetFreePlace();

            Place(product, freePlace);
        }

        public Product.Product Get()
        {
            var place = _places.FindLast(place => place.IsOccupied);

            if (place == null) return null;

            Product.Product product = place.Product;

            place.Product = null;
            place.IsOccupied = false;

            if (_isFull)
            {
                OnFreeSpace.Invoke();
                _isFull = false;
            }
            
            return product;
        }

        private Buildings.Platforms.PlatformPlace.PlatformPlace GetFreePlace()
        {
            return _places.Find(place => !place.IsOccupied);
        }

        private void Place(Product.Product product, Buildings.Platforms.PlatformPlace.PlatformPlace freePlace)
        {
            Transform productTransform;
            (productTransform = product.transform).SetParent(freePlace.transform);
            productTransform.DOLocalMove(Vector3.zero, GlobalSettings.TWEEN_DURATION);
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