using Src.Buildings.Leveling;
using Src.Characters.Carrier;
using UnityEngine;

namespace Src.Characters.Spawners
{
    public class CarrierSpawner : MonoBehaviour
    {
        [SerializeField] private CarrierLeveling _carrierPrefab;
        [SerializeField] private Route _route;
        [SerializeField] private Level _level;

        private CarrierLeveling _carrierInstance;

        private void Start()
        {
            _level.OnLevelZeroBypassed.AddListener(Create);
            _level.OnUpgrade.AddListener(Upgrade);
        }

        private void Create()
        {
            if (_carrierInstance == null)
            {
                _carrierInstance = Instantiate(_carrierPrefab);
                _carrierInstance.SetDependencies(_route.GetRoute());
            }
        }

        private void Upgrade()
        {
            _carrierInstance.Upgrade();
        }
    }
}