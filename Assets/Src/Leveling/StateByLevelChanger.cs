using System.Collections.Generic;
using UnityEngine;

namespace Src.Leveling
{
    public class StateByLevelChanger : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private List<Transform> _components;

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
            _components.ForEach(component => component.gameObject.SetActive(true));
        }

        private void DisableComponents()
        {
            _components.ForEach(component => component.gameObject.SetActive(false));
        }
    }
}