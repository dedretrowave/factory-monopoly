using System.Collections.Generic;
using Src.DI;
using UnityEngine;

namespace Src.Clients
{
    public class Route : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public Transform GetPointByIndex(int index)
        {
            return _points[index];
        }

        public List<Transform> GetRoute()
        {
            return _points;
        }
    }
}