using Src.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Src.UI.CarShop
{
    public class CarSlotUI : MonoBehaviour
    {
        [SerializeField] private RawImage _carImage;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private CarShopButtonRenderer _renderer;

        public void Fill(Car car)
        {
            _carImage.texture = car.ShopImage.texture;
            _price.text = car.Price.ToString();
            _renderer.SetCar(car);
        }
    }
}