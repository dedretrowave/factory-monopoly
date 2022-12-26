using System.Collections.Generic;
using System.ComponentModel;
using Src.Platforms;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Product
{
    public abstract class ProductTransporter : MonoBehaviour
    {
        [SerializeField] private float _maxProductsCarried = 4f;
        [SerializeField] private float _intervalBetweenProducts = 1f;

        private Stack<Product> _products = new();
        
        public UnityEvent OnProductPickup;

        protected abstract void InteractWithPlatform(Platform platform);

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out Platform platform)) return;
            
            InteractWithPlatform(platform);
        }

        protected Product GetFromPlatform(Platform platform)
        {
            if (_products.Count >= _maxProductsCarried) return null;
            
            Product product = platform.Get();

            if (product == null) return null;
            
            OnProductPickup.Invoke();
            MoveToSelf(product);

            return product;
        }

        protected void Deliver(Platform platform)
        {
            if (_products.Count == 0 || platform.IsFull) return;

            Product product = _products.Pop();

            try
            {
                platform.Add(product);
            }
            catch (WarningException e)
            {
                Debug.Log(e.Message);
                _products.Push(product);
            }
        }

        private void MoveToSelf(Product product)
        {
            if (_products.Count >= _maxProductsCarried) return;

            Transform productTransform;
            (productTransform = product.transform).SetParent(transform);
            productTransform.localPosition = new Vector3(0f, _intervalBetweenProducts * _products.Count, 0f);
            productTransform.localRotation = Quaternion.identity;

            _products.Push(product);
        }

        public void Upgrade()
        {
            _maxProductsCarried++;
        }
    }
}