using Src.Buildings.Leveling;
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
            UpdatePrice(_upgradeSpot.CostOfUpgrade);
        }

        private void UpdatePrice(float newPrice)
        {
            _text.text = Mathf.Round(newPrice).ToString();
        }
    }
}