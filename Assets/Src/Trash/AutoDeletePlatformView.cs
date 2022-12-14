using Src.Base;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;
using Vector3 = UnityEngine.Vector3;

namespace Src.Trash
{
    public class AutoDeletePlatform : Platform
    {
        private Product _product;
        
        protected override PlatformPlace GetFreePlace() => null;
        public override void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        protected override void Place(Product product, PlatformPlace freePlace)
        {
            product.transform.SetParent(transform);
            product.transform.localPosition = Vector3.zero;
            _product = product;
            Remove();
        }

        public override Product Get()
        {
            throw new System.NotImplementedException();
        }

        private void Remove()
        {
            Destroy(_product.gameObject);
        }
    }
}