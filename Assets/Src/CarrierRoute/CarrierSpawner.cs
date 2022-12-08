using Src.Clients;
using Src.Leveling;
using UnityEngine;

namespace Src.CarrierRoute
{
    public class CarrierSpawner : MonoBehaviour
    {
        [SerializeField] private RouteMovement _carrierPrefab;
        [SerializeField] private Route _route;
        [SerializeField] private Level _level;
        
        private RouteMovement _carrierInstance;

        private void Start()
        {
            _level.OnLevelZeroBypassed.AddListener(Create);
        }

        private void Create()
        {
            if (_carrierInstance == null)
            {
                _carrierInstance = Instantiate(_carrierPrefab);
                _carrierInstance.ApplyRoute(_route.GetRoute());
            }
        }
    }
}