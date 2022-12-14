using System;
using Src.Base;
using Src.Clients;
using Src.Platforms;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;

namespace Src.Player
{
    public class CarrierProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.FactoryOutput:
                case PlatformType.Money:
                    GetFromPlatform(platform);
                    break;
                case PlatformType.FactoryInput:
                case PlatformType.Trash:
                case PlatformType.Shop:
                    Deliver(platform);
                    break;
                case PlatformType.Upgrade:
                default:
                    return;
            }
        }
    }
}