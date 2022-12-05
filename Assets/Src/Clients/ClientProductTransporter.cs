using System;
using Src.Platforms.Base;
using Src.Platforms.PlatformPoint;
using UnityEngine;

namespace Src.Clients
{
    public class ClientProductTransporter : ProductTransporter
    {
        [SerializeField] private Money _moneyPrefab;
        [SerializeField] private Platform _moneyPlatform;
        
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Shop:
                    Product product = GetFromPlatform(platform);
                    if (product == null) return; 
                    TransferMoneyToPlatform();
                    break;
                case PlatformType.Trash:
                    Deliver(platform);
                    break;
                case PlatformType.Factory:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TransferMoneyToPlatform()
        {
            Money money = Instantiate(_moneyPrefab, transform);
            _moneyPlatform.Add(money);
        }
    }
}