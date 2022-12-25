using UnityEngine;

namespace Src.Movement
{
    public class PhysicsMovement : Movement
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public override void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}