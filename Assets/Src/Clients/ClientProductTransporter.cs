using Src.Base;
using Src.Platforms;
using Src.Platforms.PlatformPoint;
using UnityEngine;

namespace Src.Clients
{
    public class ClientProductTransporter : ProductTransporter
    {
        [SerializeField] private Product _moneyPrefab;
        [SerializeField] private Platform _moneyPlatform;

        public void SetDependencies(Platform moneyPlatform)
        {
            _moneyPlatform = moneyPlatform;
        }
        
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
                case PlatformType.FactoryOutput:
                case PlatformType.FactoryInput:
                default:
                    return;
            }
        }

        private void TransferMoneyToPlatform()
        {
            Product money = Instantiate(_moneyPrefab, transform);
            _moneyPlatform.Add(money);
        }
    }
}