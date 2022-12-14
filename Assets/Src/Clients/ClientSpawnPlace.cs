using Src.Platforms;
using Src.Platforms.Base;
using UnityEngine;

namespace Src.Clients
{
    public class ClientSpawnPlace : MonoBehaviour
    {
        [SerializeField] private ClientProductTransporter _clientPrefab; 
        
        private PlatformFacade _moneyPlatform;
        private Route _route;
        private ClientProductTransporter _clientInstance;

        private void Start()
        {
            if (_clientInstance == null)
            {
                _clientInstance = Instantiate(_clientPrefab);
                _clientInstance.SetDependencies(_moneyPlatform);
                _clientInstance.GetComponent<RouteMovement>().ApplyRoute(_route.GetRoute());
            }
        }

        public void SetDependencies(Route route, PlatformFacade moneyPlatform)
        {
            _route = route;
            _moneyPlatform = moneyPlatform;
        }
    }
}