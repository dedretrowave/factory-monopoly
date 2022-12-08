using System;
using Src.Base;
using Src.Clients;
using Src.Platforms;
using Src.Platforms.PlatformPoint;

namespace Src.Player
{
    public class CarrierProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Factory:
                    GetFromPlatform(platform);
                    break;
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