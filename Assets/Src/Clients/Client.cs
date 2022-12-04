using System;
using Src.Factories;
using UnityEngine;

namespace Src.Clients
{
    public class Client : MonoBehaviour
    {
        [SerializeField] private Transform _moneyPrefab;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ProductPlatform platform)) return;
            
            
        }
    }
}