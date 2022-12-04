using System;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;

namespace Src.Clients
{
    public class ClientProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Shop:
                    GetFromPlatform(platform);
                    break;
                case PlatformType.Factory:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
    }
}