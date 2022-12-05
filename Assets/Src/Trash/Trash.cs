using Src.Platforms.Base;
using UnityEngine;

namespace Src.Trash
{
    public class Trash : MonoBehaviour
    {
        [SerializeField] private Platform _platform;

        private void Start()
        {
            _platform.OnPlace.AddListener(Remove);
        }

        private void Remove(Product product)
        {
            Destroy(product.gameObject);
        }
    }
}