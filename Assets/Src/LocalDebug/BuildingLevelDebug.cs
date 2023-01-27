using System.Collections.Generic;
using Src.Buildings.Leveling;
using TMPro;
using UnityEngine;

namespace Src.LocalDebug
{
    public class BuildingLevelDebug : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private List<Level> _levels;

        private void Start()
        {
            _levels.ForEach(level =>
            {
                level.OnUpgrade.AddListener(UpdateText);
            });
        }

        private void UpdateText()
        {
            _text.text = "";
            
            _levels.ForEach(level =>
            {
                _text.text += $"{level.Id} : {level.CurrentLevel}\n";
            });
        }
    }
}