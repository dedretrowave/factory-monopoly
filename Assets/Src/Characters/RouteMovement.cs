using System.Collections.Generic;
using Src.Movement;
using UnityEngine;

namespace Src.Characters
{
    public class RouteMovement : MonoBehaviour
    {
        [SerializeField] private NonPhysicsMovement _movement;
        [SerializeField] private float _rotationDistance = 1f;
        [SerializeField] private List<Transform> _points;

        private Vector3 _direction;

        private int _startPointIndex = 0;
        private int _endPointIndex = 1;

        public void ApplyRoute(List<Transform> route)
        {
            _points = route;
            
            transform.position = _points[_startPointIndex].position;

            _direction = (_points[_endPointIndex].position - _points[_startPointIndex].position).normalized;
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, _points[_endPointIndex].position) <= _rotationDistance)
            {
                _movement.Rotate(_direction);
                ChangeDirection();
            }

            _movement.Move(_direction);
        }

        private void ChangeDirection()
        {
            _startPointIndex = _endPointIndex;

            _endPointIndex += 1;

            if (_endPointIndex >= _points.Count)
            {
                _endPointIndex = 0;
            }

            _direction = (_points[_endPointIndex].position - _points[_startPointIndex].position).normalized;
        }
    }
}