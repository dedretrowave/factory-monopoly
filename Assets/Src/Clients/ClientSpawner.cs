using System.Collections.Generic;
using Src.Leveling;
using Src.Platforms;
using UnityEngine;

namespace Src.Clients
{
    public class ClientSpawner : MonoBehaviour
    {
        [SerializeField] private ClientSpawnPlace _clientSpawnPlacePrefab;
        [SerializeField] private Level _shopLevel;
        [SerializeField] private List<Transform> _points;
        [Header("Dependencies")] 
        [SerializeField] private Route _clientRoute;
        [SerializeField] private Platform _moneyPlatform;

        private int _objectsSpawned;

        private void Start()
        {
            _shopLevel.OnUpgrade.AddListener(Spawn);
        }

        private void Spawn()
        {
            ClientSpawnPlace place = Instantiate(_clientSpawnPlacePrefab, transform);

            place.SetDependencies(_clientRoute, _moneyPlatform);

            place.transform.SetParent(_points[_objectsSpawned]);
            place.transform.position = _points[_objectsSpawned].position;
            
            _objectsSpawned++;
        }
    }
}