using UnityEngine;

namespace Src.Movement.Base
{
    public class NonPhysicsMovement : Movement
    {
        public override void Move(Vector3 direction)
        {
            transform.position += direction * _speed * Time.deltaTime;
        }
    }
}