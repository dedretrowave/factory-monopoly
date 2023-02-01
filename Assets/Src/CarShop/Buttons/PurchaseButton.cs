using Src.CarShop.Buttons.Base;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class PurchaseButton : CarShopButton
    {
        public void Click()
        {
            Debug.Log("CAR CHECK: " + this.car);
            car.IsPurchased = true;
        }
    }
}