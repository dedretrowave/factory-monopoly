using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src.Leveling
{
    public class StateByLevelChanger : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] [Tooltip("Components To Enable After Level 1")] 
        private List<Transform> _levelZeroDisabledComponents;

        private int _currentLevel;

        private void Start()
        {
            _currentLevel = _level.CurrentLevel;

            if (_currentLevel == 0)
            {
                DisableComponents();
            }
            
            _level.OnLevelZeroBypassed.AddListener(EnableComponents);
            
        }

        private void EnableComponents()
        {
            _levelZeroDisabledComponents.ForEach(component => component.gameObject.SetActive(true));
        }

        private void DisableComponents()
        {
            _levelZeroDisabledComponents.ForEach(component => component.gameObject.SetActive(false));
        }
    }
}