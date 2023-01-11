using Src.Buildings.Platforms;
using UnityEngine;

namespace Src.Characters.Clients
{
    public class ClientSpawnPlace : MonoBehaviour
    {
        [SerializeField] private Transform _clientPrefab;

        [SerializeField] private float _spawnOffset = 2f;
        
        private Platform _moneyPlatform;
        private Route _route;
        private ClientProductTransporter _clientInstance;

        private void Start()
        {
            if (_clientInstance == null)
            {
                Transform newClient = Instantiate(_clientPrefab);
                _clientInstance = newClient.GetComponentInChildren<ClientProductTransporter>();
                _clientInstance.SetDependencies(_moneyPlatform);
                newClient
                    .GetComponent<RouteMovement>()
                    .ApplyRoute(
                        _route.GetRoute(),
                        new Vector3(
                            transform.position.x,
                            transform.position.y,
                            transform.position.z + _spawnOffset)
                        );
            }
        }

        public void SetDependencies(Route route, Platform moneyPlatform)
        {
            _route = route;
            _moneyPlatform = moneyPlatform;
        }
    }
}