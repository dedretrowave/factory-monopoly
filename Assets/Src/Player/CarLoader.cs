using Src.Models;
using UnityEngine;

namespace Src.Player
{
    public class CarLoader : MonoBehaviour
    {
        [SerializeField] private Transform _currentCarTransform;
        private Car _currentCar;

        public Car CurrentCar => _currentCar;

        public void LoadNew(Car newCar)
        {
            _currentCar = newCar;
            
            Destroy(_currentCarTransform.transform.gameObject);
            _currentCarTransform = Instantiate(_currentCar.Prefab, transform);
        }
    }
}