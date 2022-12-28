using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DG.Tweening;
using Src.Misc;
using Src.Platforms;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Product
{
    public abstract class ProductTransporter : MonoBehaviour
    {
        [SerializeField] private float _maxProductsCarried = 4f;
        [SerializeField] private float _intervalBetweenProducts = 1f;
        [SerializeField] private float _productPickupDelay = .4f;

        private Stack<Product> _products = new();
        private ExecutionQueue _pickupQueue;

        public UnityEvent OnProductPickup;

        protected abstract void InteractWithPlatform(Platform platform);

        private void Start()
        {
            _pickupQueue = gameObject.AddComponent<ExecutionQueue>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out Platform platform)) return;
            
            InteractWithPlatform(platform);
        }

        protected void GetFromPlatform(Platform platform)
        {
            if (_products.Count >= _maxProductsCarried) throw new Exception("Too much products");
            
            Product product = platform.Get();

            if (product == null) throw new Exception("Platform is empty");

            MoveToSelf(product);
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
            
            Vector3 endPoint = new Vector3(
                0f, 
                _intervalBetweenProducts * _products.Count,
                0f);

            productTransform.DOLocalMove(endPoint, _productPickupDelay);
            productTransform.localRotation = Quaternion.identity;
            
            OnProductPickup.Invoke();

            _products.Push(product);
        }

        public void Upgrade()
        {
            _maxProductsCarried++;
        }
    }
}