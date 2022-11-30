using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Src
{
    [Serializable]
    public class PlatformPoint
    {
        public Transform Transform;
        public bool IsOccupied;

        public PlatformPoint(Transform transform, bool isFree)
        {
            Transform = transform;
            IsOccupied = isFree;
        }

        public PlatformPoint(Transform transform)
        {
            Transform = transform;
            IsOccupied = true;
        }
    }
    
    public class Platform : MonoBehaviour
    {
        [SerializeField] private List<PlatformPoint> _points = new();
        private bool _isFull;

        public UnityEvent OnOutOfSpace;
        public UnityEvent OnFreeSpace;

        public void Spawn(Product product)
        {
            PlatformPoint freePoint = _points.Find(point => !point.IsOccupied);

            if (freePoint == null)
            {
                OnOutOfSpace.Invoke();
                Destroy(product);
                return;
            }
            
            product.transform.SetParent(freePoint.Transform);
            product.transform.localPosition = Vector3.zero;
            freePoint.IsOccupied = true;
        }
    }
}