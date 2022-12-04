using System;
using Src.Factories;
using Src.Platforms;
using Src.Platforms.Base;
using UnityEngine;

namespace Src.Clients
{
    public class Client : MonoBehaviour
    {
        [SerializeField] private Transform _moneyPrefab;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Platform platform)) return;
            
            
        }
    }
}