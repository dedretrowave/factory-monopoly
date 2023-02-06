using DI;
using Src.CarShop.Buttons.Base;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class SelectButton : CarShopButton
    {
        public void Click()
        {
            DependencyContext.Dependencies.Get<CarStateSwitcher>().Select(car);
        }
    }
}