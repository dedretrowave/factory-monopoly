using System;
using Src.Buildings.Platforms;
using Src.Buildings.Platforms.PlatformPlace;
using Src.Product;
using UnityEngine;

namespace Src.Player
{
    public class DefaultProductTransporter : ProductTransporter
    {
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.FactoryOutput:
                    try
                    {
                        GetFromPlatform(platform);
                    }
                    catch (Exception e)
                    {
#if UNITY_EDITOR
                        // Debug.Log(e.Message);
#endif
                    }

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