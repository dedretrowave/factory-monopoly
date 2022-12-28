using Src.Platforms;
using Src.Platforms.PlatformPoint;
using Src.Product;

namespace Src.ProductTransporting
{
    public class DefaultProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.FactoryOutput:
                    GetFromPlatform(platform);
                    break;
                case PlatformType.FactoryInput:
                case PlatformType.Trash:
                case PlatformType.Shop:
                    Deliver(platform);
                    break;
                case PlatformType.Money:
                case PlatformType.Upgrade:
                default:
                    return;
            }
        }
    }
}