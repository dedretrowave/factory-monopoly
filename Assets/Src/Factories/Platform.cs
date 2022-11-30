using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Src.Factories
{
    [Serializable]
    public class PlatformPlace
    {
        public Transform Transform;
        public bool IsOccupied;
        public Product Product;

        public PlatformPlace(Transform transform, Product product, bool isFree = true)
        {
            Transform = transform;
            IsOccupied = isFree;
        }
    }
    
    public class Platform : MonoBehaviour
    {
        [SerializeField] private List<PlatformPlace> _places = new();
        private bool _isFull;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;

        public void Spawn(Product product)
        {
            PlatformPlace freePoint = _places.Find(place => !place.IsOccupied);

            if (freePoint == null)
            {
                OnOutOfSpace.Invoke();
                Destroy(product);
                return;
            }

            product.transform.SetParent(freePoint.Transform);
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
            OnFreeSpace.Invoke();

            return product;
        }
    }
}