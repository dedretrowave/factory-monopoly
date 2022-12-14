using Src.Base;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;

namespace Src.Platforms
{
    public class VerticalStackPlatform : Platform
    {
        protected override PlatformPlace GetFreePlace()
        {
            throw new System.NotImplementedException();
        }

        public override void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        protected override void Place(Product product, PlatformPlace freePlace)
        {
            throw new System.NotImplementedException();
        }

        public override Product Get()
        {
            throw new System.NotImplementedException();
        }
    }
}