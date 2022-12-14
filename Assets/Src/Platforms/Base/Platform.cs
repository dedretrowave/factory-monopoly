using Src.Base;
using Src.Platforms.PlatformPoint;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Platforms.Base
{
    public abstract class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _type;
        [SerializeField] 
        
        protected bool _isFull;

        public PlatformType Type => _type;
        public bool IsFull => _isFull;
        
        [HideInInspector]
        public UnityEvent OnOutOfSpace;
        [HideInInspector]
        public UnityEvent OnFreeSpace;
        [HideInInspector]
        public UnityEvent OnPlace;

        protected abstract PlatformPlace GetFreePlace();

        public abstract void Add(Product product);
        
        protected abstract void Place(Product product, PlatformPlace freePlace);
        
        public abstract Product Get();
    }
}