using System;
using System.Collections.Generic;
using Src.Factories;
using Src.Factories.PlatformPoint;
using UnityEngine;

namespace Src.Player
{
    public class ProductCollector : MonoBehaviour
    {
        [SerializeField] private float _maxProductsCarried = 4f;

        private Stack<Product> _products = new();

        private void OnTriggerStay(Collider other)
        {
            if (_products.Count >= _maxProductsCarried
                || !other.TryGetComponent(out Platform platform)) return;

            switch (platform.Type)
            {
                case PlatformType.Factory:
                    Take(platform);
                    break;
                case PlatformType.Shop:
                    Give(platform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Take(Platform platform)
        {
            Product product = platform.GetProduct();

            if (product == null) return;
            
            Collect(product);
        }

        private void Give(Platform platform)
        {
            Product product = _products.Pop();
            
            platform.AddProduct(product);
        }

        private void Collect(Product product)
        {
            product.transform.SetParent(transform);
            product.transform.localPosition = new Vector3(0f, 1f * _products.Count, 0f);
            
            _products.Push(product);
        }
    }
}