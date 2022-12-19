using System;
using System.ComponentModel;
using Src.Base;
using Src.Platforms;
using Src.Platforms.PlatformPoint;
using UnityEngine;

namespace Src.Player
{
    public class MoneyTransporter : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Product _moneyPrefab;

        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent(out Platform platform)) return;

            switch (platform.Type)
            {
                case PlatformType.Money:
                    Product money = platform.Get();
                    
                    if (money == null || money.Type != ProductType.Money)
                    {
                        return;
                    }
                    
                    Destroy(money.gameObject);
                    _wallet.Add();
                    break;
                case PlatformType.Upgrade:
                    try
                    {
                        _wallet.Reduce();
                    }
                    catch (WarningException)
                    {
                        return;
                    }
                    
                    Product mockMoney = Instantiate(_moneyPrefab, transform);
                    platform.Add(mockMoney);
                    break;
                case PlatformType.FactoryOutput:
                case PlatformType.FactoryInput:
                case PlatformType.Shop:
                case PlatformType.Trash:
                default:
                    return;
            }
        }
    }
}