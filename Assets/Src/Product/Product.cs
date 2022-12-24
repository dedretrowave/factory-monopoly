using UnityEngine;

namespace Src.Product
{
    public class Product : MonoBehaviour
    {
        [SerializeField] protected float _price;
        [SerializeField] protected ProductType _type;

        public ProductType Type => _type;
        public float Price => _price;
    }
}