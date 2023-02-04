using Src.Models;
using Src.UI.CarShop;
using UnityEngine;

namespace Src.CarShop.Buttons.Base
{
    public abstract class CarShopButton : MonoBehaviour
    {
        [SerializeField] private CarShopButtonUI _ui;
        
        protected Car Car;

        public void SetUp(Car car)
        {
            Car = new Car(car);
            _ui.Fill(Car);
        }

        public abstract void Click();
    }
}