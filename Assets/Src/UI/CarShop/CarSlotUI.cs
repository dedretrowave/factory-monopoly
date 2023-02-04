using Src.CarShop.Buttons;
using Src.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Src.UI.CarShop
{
    public class CarSlotUI : MonoBehaviour
    {
        [SerializeField] private RawImage _carImage;
        [SerializeField] private CarShopButtonRenderer _button;

        public void Fill(Car car)
        {
            _carImage.texture = car.ShopImage.texture;
            _button.SetUp(car);
        }
    }
}