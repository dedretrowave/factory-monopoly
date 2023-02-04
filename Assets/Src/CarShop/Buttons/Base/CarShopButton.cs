using Src.Models;
using Src.UI.CarShop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Src.CarShop.Buttons.Base
{
    public abstract class CarShopButton : MonoBehaviour
    {
        [SerializeField] private CarShopButtonUI _ui;

        protected int CarId = -1;

        public void SetUp(Car car)
        {
            CarId = car.Id;
            _ui.Fill(car);
        }

        public abstract void Click();
    }
}