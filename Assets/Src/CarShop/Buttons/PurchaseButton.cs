using DI;
using Src.CarShop.Buttons.Base;

namespace Src.CarShop.Buttons
{
    public class PurchaseButton : CarShopButton
    {
        public void Click()
        {
            DependencyContext.Dependencies.Get<CarStateSwitcher>().Purchase(car);
        }
    }
}