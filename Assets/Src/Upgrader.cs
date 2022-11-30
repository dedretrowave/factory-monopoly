using UnityEngine;
using UnityEngine.Events;

namespace Src
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        
        private int _currentLevel;

        public UnityEvent<int> OnUpgrade;

        public void Upgrade()
        {
            int newLevel = _currentLevel + 1;

            if (newLevel >= _maxLevel)
            {
                _currentLevel = _maxLevel;
                OnUpgrade.Invoke(_currentLevel);
                return;
            }

            _currentLevel = newLevel;
            OnUpgrade.Invoke(_currentLevel);
        }
    }
}