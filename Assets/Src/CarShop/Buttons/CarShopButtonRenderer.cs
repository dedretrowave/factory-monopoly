using System;
using System.Collections.Generic;
using Src.CarShop.Buttons.Base;
using Src.Models;
using UnityEngine;

namespace Src.CarShop.Buttons
{
    public class CarShopButtonRenderer : MonoBehaviour
    {
        [SerializeField] private List<CarStateToButton> _buttonsWithStates = new();

        public void SetUp(Car car)
        {
            CarShopButton shopButton = _buttonsWithStates.Find(button => button.State == car.State).Button;

            shopButton.gameObject.SetActive(true);
            shopButton.SetUp(car);
        }
    }

    [Serializable]
    internal class CarStateToButton
    {
        public CarState State;
        public CarShopButton Button;
    }
}