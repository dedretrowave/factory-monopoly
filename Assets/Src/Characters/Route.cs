using System.Collections.Generic;
using UnityEngine;

namespace Src.Characters
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