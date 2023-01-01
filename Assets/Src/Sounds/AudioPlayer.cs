using Src.Player;
using Src.Product;
using UnityEngine;

namespace Src.Sounds
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _itemPickupSound;
        [SerializeField] private AudioClip _moneyPickupSound;
        [Header("Components")]
        [SerializeField] private ProductTransporter _productTransporter;
        [SerializeField] private MoneyTransporter _moneyTransporter;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _productTransporter.OnProductPickup.AddListener(PlayProductPickup);
            _moneyTransporter.OnMoneyPickup.AddListener(PlayMoneyPickup);
        }

        private void PlayProductPickup(Product.Product _)
        {
            SetAudioClipAndPlay(_itemPickupSound);
        }

        private void PlayMoneyPickup()
        {
            SetAudioClipAndPlay(_moneyPickupSound);
        }

        private void SetAudioClipAndPlay(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}