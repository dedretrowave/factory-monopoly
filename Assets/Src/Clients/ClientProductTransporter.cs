using System;
using Src.Platforms;
using Src.Platforms.PlatformPoint;
using Src.Product;
using UnityEngine;

namespace Src.Clients
{
    public class ClientProductTransporter : ProductTransporter
    {
        [SerializeField] private Product.Product _moneyPrefab;
        [SerializeField] private Platform _moneyPlatform;

        private new void Start()
        {
            base.Start();
            OnProductPickup.AddListener(TransferMoneyToPlatform);
        }

        public void SetDependencies(Platform moneyPlatform)
        {
            _moneyPlatform = moneyPlatform;
        }
        
        protected override void InteractWithPlatform(Platform platform)
        {
            switch (platform.Type)
            {
                case PlatformType.Shop:
                    try
                    {
                        GetFromPlatform(platform);
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                    break;
                case PlatformType.Trash:
                    Deliver(platform);
                    break;
                case PlatformType.FactoryOutput:
                case PlatformType.FactoryInput:
                default:
                    return;
            }
        }

        private void TransferMoneyToPlatform()
        {
            Product.Product money = Instantiate(_moneyPrefab, transform);
            _moneyPlatform.Add(money);
        }
    }
}