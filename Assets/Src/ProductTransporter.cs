using System.Collections.Generic;
using Src.Platforms;
using Src.Platforms.Base;
using UnityEngine;

namespace Src
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

        protected void GetFromPlatform(Platform platform)
        {
            Product product = platform.Get();

            if (product == null) return;
            
            MoveToSelf(product);
        }

        protected void Deliver(Platform platform)
        {
            if (_products.Count == 0 || platform.IsFull) return;

            Product product = _products.Pop();
            
            platform.Add(product);
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