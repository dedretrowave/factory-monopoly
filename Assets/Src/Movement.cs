using UnityEngine;

namespace Src
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        public void Move(Vector3 direction)
        {
            transform.position += direction * (_speed * Time.deltaTime);
        }

        public void Rotate(Vector3 direction)
        {
            transform.LookAt(transform.position - direction);
        }
    }
}