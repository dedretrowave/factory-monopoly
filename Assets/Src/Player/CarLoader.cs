using Src.Models;
using UnityEngine;

namespace Src.Player
{
    public class CarLoader : MonoBehaviour
    { 
        [SerializeField] private Car _currentCar;

        public void LoadNew(Car _newCar)
        {
            Debug.Log($"SELECTED: {_newCar}");
            Destroy(_currentCar.gameObject);
            _currentCar = Instantiate(_newCar, transform);
        }
    }
}