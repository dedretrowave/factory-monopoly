using Src.Platforms;
using Src.ProductTransporting;
using UnityEngine;

namespace Src.Clients
{
    public class ClientSpawnPlace : MonoBehaviour
    {
        [SerializeField] private Transform _clientPrefab; 
        
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
                newClient.GetComponent<RouteMovement>().ApplyRoute(_route.GetRoute());
            }
        }

        public void SetDependencies(Route route, Platform moneyPlatform)
        {
            _route = route;
            _moneyPlatform = moneyPlatform;
        }
    }
}