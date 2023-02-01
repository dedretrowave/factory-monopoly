using Src.Models;
using UnityEngine;

namespace Src.Player
{
    public class CarLoader : MonoBehaviour
    { 
        private Car _currentCar;

        public void LoadNew(Car _newCar)
        {
            Destroy(GetComponentInChildren<Transform>().gameObject);
            _currentCar = Instantiate(_newCar, transform);
        }
    }
}