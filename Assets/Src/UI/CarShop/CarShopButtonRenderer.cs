using System;
using System.Collections.Generic;
using Src.CarShop.Buttons.Base;
using Src.Models;
using UnityEngine;

namespace Src.UI.CarShop
{
    public class CarShopButtonRenderer : MonoBehaviour
    {
        [SerializeField] private List<ButtonToState> _buttons = new();
        [SerializeField] private CarShopButton _currentSelectedButton;

        public void SetCar(Car car)
        {
            car.OnStateChange.AddListener(Render);
            Render(car);
        }

        private void Render(Car car)
        {
            _buttons.ForEach(button => button.Button.SetCar(car));
            
            _currentSelectedButton.gameObject.SetActive(false);
            _currentSelectedButton = _buttons.Find(button => button.State == car.State).Button;
            _currentSelectedButton.gameObject.SetActive(true);
        }
    }
    
    [Serializable]
    internal class ButtonToState
    {
        public CarState State;
        public CarShopButton Button;
    }
}