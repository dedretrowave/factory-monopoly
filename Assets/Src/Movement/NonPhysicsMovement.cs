using UnityEngine;

namespace Src.Movement
{
    public class NonPhysicsMovement : Base.Movement
    {
        public override void Move(Vector3 direction)
        {
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}