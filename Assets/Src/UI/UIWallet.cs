using Src.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Src.UI
{
    public class UIWallet : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Text _text;

        private void Start()
        {
            _wallet.OnMoneyChange.AddListener(UpdateText);
        }

        private void UpdateText(int newValue)
        {
            _text.text = newValue.ToString();
        }
    }
}