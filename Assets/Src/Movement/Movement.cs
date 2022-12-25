using UnityEngine;

namespace Src.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        public void MultiplySpeed(float number)
        {
            _speed *= number;
        }

        public abstract void Move(Vector3 direction);

        public void Rotate(Vector3 direction)
        {
            transform.LookAt(transform.position - direction);
        }
    }
}