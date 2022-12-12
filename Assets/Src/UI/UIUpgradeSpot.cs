using Src.Leveling;
using TMPro;
using UnityEngine;

namespace Src.UI
{
    public class UIUpgradeSpot : MonoBehaviour
    {
        [SerializeField] private UpgradeSpot _upgradeSpot;
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            _upgradeSpot.OnPriceChange.AddListener(UpdatePrice);
        }

        private void UpdatePrice(float newPrice)
        {
            _text.text = newPrice.ToString();
        }
    }
}