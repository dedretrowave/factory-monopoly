using Src.CarShop.Buttons.Base;
using Src.Models;

namespace Src.CarShop.Buttons
{
    public class SelectButton : CarShopButton
    {
        public override void Click()
        {
            Car.State = CarState.Selected;
        }
    }
}