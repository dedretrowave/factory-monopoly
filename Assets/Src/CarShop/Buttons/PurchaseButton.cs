using Src.CarShop.Buttons.Base;
using Src.Models;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class PurchaseButton : CarShopButton
    {
        public override void Click()
        {
            Debug.Log($"{Car.Name} PURCHASED");
            Car.State = CarState.Purchased;
        }
    }
}