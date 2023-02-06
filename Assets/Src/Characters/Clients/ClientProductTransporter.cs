using System;
using Src.Buildings.Platforms;
using Src.Buildings.Platforms.PlatformPlace;
using Src.Product;
using UnityEngine;

namespace Src.Characters.Clients
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
#if UNITY_EDITOR
                        // Debug.Log(e.Message);
#endif
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

        private void TransferMoneyToPlatform(Product.Product product)
        {
            for (var i = 0; i < product.Price; i++)
            {
                Product.Product money = Instantiate(_moneyPrefab, transform);
                _moneyPlatform.Add(money);
            }
        }
    }
}