using DI;
using Src.CarShop.Buttons.Base;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class SelectButton : CarShopButton
    {
        public override void Click()
        {
            Debug.Log($"SELECTING CAR {CarId}");
            CarStateSwitcher carStateSwitcher = DependencyContext.Dependencies.Get<CarStateSwitcher>();
            
            carStateSwitcher.SwitchToSelected(CarId);
        }
    }
}