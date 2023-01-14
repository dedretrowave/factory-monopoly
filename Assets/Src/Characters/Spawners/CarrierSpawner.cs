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

        private void Awake()
        {
            _level.OnLevelZeroBypassed.AddListener(Create);
            _level.OnUpgrade.AddListener(Upgrade);
        }

        private void Create()
        {
            if (_carrierInstance == null)
            {
                _carrierInstance = Instantiate(_carrierPrefab);
                var transformPosition = _carrierInstance.transform.position;
                transformPosition.y = 0f;
                _carrierInstance.SetDependencies(_route.GetRoute());
            }
        }

        private void Upgrade()
        {
            _carrierInstance.Upgrade();
        }
    }
}