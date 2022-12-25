using System.Collections.Generic;
using Src.ProductTransporting;
using UnityEngine;

namespace Src.Carrier
{
    public class CarrierLeveling : MonoBehaviour
    {
        [SerializeField] private RouteMovement _routeMovement;
        [SerializeField] private Movement.Base.NonPhysicsMovement _movement;
        [SerializeField] private DefaultProductTransporter _defaultProductTransporter;
        [SerializeField] private float _speedByLevelIncrease;

        public void SetDependencies(List<Transform> points)
        {
            _routeMovement.ApplyRoute(points);
        }

        public void Upgrade()
        {
            _movement.MultiplySpeed(_speedByLevelIncrease);
            _defaultProductTransporter.Upgrade();
        }
    }
}