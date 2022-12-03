using System;
using System.Collections.Generic;
using Src.Factories;
using Src.Factories.PlatformPoint;
using UnityEngine;

namespace Src.Player
{
    public class ProductTransporter : MonoBehaviour
    {
        [SerializeField] private float _maxProductsCarried = 4f;

        private Stack<Product> _products = new();

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out ProductPlatform platform)) return;

            switch (platform.Type)
            {
                case PlatformType.Factory:
                    Take(platform);
                    break;
                case PlatformType.Shop:
                    Deliver(platform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Take(ProductPlatform platform)
        {
            Product product = platform.Get();

            if (product == null) return;
            
            Collect(product);
        }

        private void Deliver(ProductPlatform platform)
        {
            if (_products.Count == 0 || platform.IsFull) return;

            Product product = _products.Pop();
            
            platform.Add(product);
        }

        private void Collect(Product product)
        {
            if (_products.Count >= _maxProductsCarried) return;
            
            product.transform.SetParent(transform);
            product.transform.localPosition = new Vector3(0f, 1f * _products.Count, 0f);
            
            _products.Push(product);
        }
    }
}