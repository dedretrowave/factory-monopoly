using System.Collections.Generic;
using Src.Base;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;
using UnityEngine;

namespace Src.Platforms
{
    public class PlainPlatform : Platform
    {
        [SerializeField] private List<PlatformPlace> _places;

        public override void Add(Product product)
        {
            PlatformPlace freePlace = GetFreePlace();

            if (freePlace == null) return;
            
            Place(product, freePlace);

            if (GetFreePlace() == null)
            {
                OnOutOfSpace.Invoke();
            }
        }

        protected override void Place(Product product, PlatformPlace freePlace)
        {
            product.transform.SetParent(freePlace.transform);
            product.transform.localPosition = Vector3.zero;
            freePlace.Product = product;
            freePlace.IsOccupied = true;
            OnPlace.Invoke();
        }

        public override Product Get()
        {
            PlatformPlace place = _places.FindLast(place => place.IsOccupied);

            if (place == null) return null;

            Product product = place.Product;
            
            place.IsOccupied = false;
            place.Product = null;

            return product;
        }
        
        protected override PlatformPlace GetFreePlace()
        {
            PlatformPlace freePlace = _places.Find(place => !place.IsOccupied);

            return freePlace;
        }
    }
}