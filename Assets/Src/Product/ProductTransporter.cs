using System;
using System.Collections;
using System.Collections.Generic;
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

        private Stack<Product> _products = new();
        private ExecutionQueue _pickupQueue;

        public UnityEvent OnProductPickup;

        protected abstract void InteractWithPlatform(Platform platform);

        protected void Start()
        {
            _pickupQueue = gameObject.AddComponent<ExecutionQueue>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out Platform platform)) return;
            
            InteractWithPlatform(platform);
        }
        
        private IEnumerator MoveToSelfWithDelay(Product product)
        {
            MoveToSelf(product);

            yield return new WaitForSeconds(GlobalSettings.TWEEN_DURATION);
        }
        
        private void MoveToSelf(Product product)
        {
            Transform productTransform;
            (productTransform = product.transform).SetParent(transform);
            
            Vector3 endPoint = new Vector3(
                0f,
                _intervalBetweenProducts * _products.Count,
                0f);

            productTransform.DOLocalMove(endPoint, GlobalSettings.TWEEN_DURATION);
            productTransform.localRotation = Quaternion.identity;

            OnProductPickup.Invoke();
        }

        protected void GetFromPlatform(Platform platform)
        {
            if (_products.Count >= _maxProductsCarried) throw new Exception("Too much products");
            
            Product product = platform.Get();

            if (product == null) throw new Exception("Platform is empty");
            
            _products.Push(product);

            _pickupQueue.Add(MoveToSelfWithDelay(product));
        }

        protected void Deliver(Platform platform)
        {
            if (_products.Count == 0 || platform.IsFull) return;

            Product product = _products.Pop();

            try
            {
                platform.Add(product);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                _products.Push(product);
            }
        }

        public void Upgrade()
        {
            _maxProductsCarried++;
        }
    }
}