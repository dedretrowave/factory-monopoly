using Src.Models;
using UnityEngine;

namespace Src.CarShop.Buttons.Base
{
    public abstract class CarShopButton : MonoBehaviour
    {
        [SerializeField] protected Car car;

        public void SetCar(Car car)
        {
            this.car = car;
        }
    }
}