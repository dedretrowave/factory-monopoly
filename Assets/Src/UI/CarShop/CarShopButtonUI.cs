using Src.Models;
using TMPro;
using UnityEngine;

namespace Src.UI.CarShop
{
    public class CarShopButtonUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _price;

        public void Fill(Car car)
        {
            if (_price == null) return;
            _price.text = car.Price.ToString();
        }
    }
}