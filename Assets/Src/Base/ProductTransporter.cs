using System.Collections.Generic;
using System.ComponentModel;
using Src.Platforms;
using UnityEngine;

namespace Src.Base
{
    public abstract class ProductTransporter : MonoBehaviour
    {
        [SerializeField] private float _maxProductsCarried = 4f;

        private Stack<Product> _products = new();

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
            
            product.transform.SetParent(transform);
            product.transform.localPosition = new Vector3(0f, 1f * _products.Count, 0f);
            
            _products.Push(product);
        }
    }
}