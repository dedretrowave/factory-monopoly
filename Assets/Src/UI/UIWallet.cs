using Src.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Src.UI
{
    public class UIWallet : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _wallet.OnMoneyChange.AddListener(UpdateText);
            UpdateText(_wallet.CurrentMoney);
        }

        private void UpdateText(int newValue)
        {
            _text.text = newValue.ToString();
        }
    }
}