using UnityEngine;

namespace Src.Player
{
    public class CarBootstrap : MonoBehaviour
    {
        [SerializeField] private CarLoader _loader;
        [SerializeField] private CarShop.CarShop _shop;

        private void Start()
        {
            LoadSelectedCar();
        }

        private void LoadSelectedCar()
        {
            _loader.LoadNew(_shop.GetSelectedCar());
        }
    }
}