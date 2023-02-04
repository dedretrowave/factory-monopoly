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

        private CarShopButton _button;
        private Car _car;

        public void SetUp(Car car)
        {
            _car = car;
            RenderButton();
        }

        private void RenderButton()
        {
            Debug.Log("RENDER NEW BUTTON!!!");
            if (_button != null) _button.gameObject.SetActive(false);

            _button = _buttonsWithStates.Find(button => button.State == _car.State).Button;

            _button.gameObject.SetActive(true);
            _button.SetUp(_car);
        }
    }

    [Serializable]
    internal class CarStateToButton
    {
        public CarState State;
        public CarShopButton Button;
    }
}