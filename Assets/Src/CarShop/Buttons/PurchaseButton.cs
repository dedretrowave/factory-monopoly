using DI;
using Src.CarShop.Buttons.Base;
using Src.Models;
using Src.UI.CarShop;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class PurchaseButton : MonoBehaviour
    {
        [SerializeField] private CarShopButtonUI _ui;

        protected int CarId = 2;

        public void SetUp(Car car)
        {
            CarId = car.Id;
            _ui.Fill(car);
        }
        
        public void Click()
        {
            Debug.Log($"PURCHASING CAR {CarId}");
            CarStateSwitcher carStateSwitcher = DependencyContext.Dependencies.Get<CarStateSwitcher>();
            
            carStateSwitcher.SwitchToPurchased(CarId);
        }
    }
}