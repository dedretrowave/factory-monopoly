using System;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;

namespace Src.Player
{
    public class PlayerProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Factory:
                    GetFromPlatform(platform);
                    break;
                case PlatformType.Shop:
                    Deliver(platform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}