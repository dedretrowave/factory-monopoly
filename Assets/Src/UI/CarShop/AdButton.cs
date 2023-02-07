using DI;
using Src.CarShop;
using Src.Models;
using UnityEngine;

namespace Src.UI.CarShop
{
    public class AdButton : MonoBehaviour
    {
        [SerializeField] private int _usageDuration = 180;

        private CarStateSwitcher _carStateSwitcher;
        private Car _car;
        private Ads.Base.Ads _ads;

        private void Start()
        {
            _carStateSwitcher = DependencyContext.Dependencies.Get<CarStateSwitcher>();
            _ads = DependencyContext.Dependencies.Get<Ads.Base.Ads>();
        }

        public void SetCar(Car car)
        {
            _car = car;
        }

        public void LaunchAd()
        {
            _ads.OnRewardedAdWatched.AddListener(GiveBonus);
            _ads.ShowRewardedAd();
        }

        private void GiveBonus()
        {
            _carStateSwitcher.SwitchForTime(_car, _usageDuration);
            _ads.OnRewardedAdWatched.RemoveListener(GiveBonus);
        }
    }
}