using System.Collections.Generic;
using Src.Movement;
using Src.Player;
using UnityEngine;

namespace Src.Characters.Carrier
{
    public class CarrierLeveling : MonoBehaviour
    {
        [SerializeField] private RouteMovement _routeMovement;
        [SerializeField] private NonPhysicsMovement _movement;
        [SerializeField] private DefaultProductTransporter _defaultProductTransporter;
        [SerializeField] private float _speedByLevelIncrease;

        public void SetDependencies(List<Transform> points)
        {
            _routeMovement.ApplyRoute(points, Vector3.zero);
        }

        public void Upgrade()
        {
            _movement.MultiplySpeed(_speedByLevelIncrease);
            _defaultProductTransporter.Upgrade();
        }
    }
}