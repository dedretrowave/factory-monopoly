using Src.Buildings.Platforms;
using UnityEngine;

namespace Src.Buildings.Trash
{
    public class Trash : MonoBehaviour
    {
        [SerializeField] private Platform _platform;

        private void Start()
        {
            _platform.OnPlace.AddListener(Remove);
        }

        private void Remove()
        {
            Product.Product product = _platform.Get();
            Destroy(product.gameObject);
        }
    }
}