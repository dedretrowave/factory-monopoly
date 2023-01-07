using UnityEngine;
using UnityEngine.Events;

namespace Src.Buildings.Leveling
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        
        private int _currentLevel = 0;

        public UnityEvent OnUpgrade;
        public UnityEvent OnLevelZeroBypassed;
        public UnityEvent OnMaxLevelReached;

        public int CurrentLevel => _currentLevel;

        public void Upgrade()
        {
            if (_currentLevel == 0) OnLevelZeroBypassed.Invoke();
            
            int newLevel = _currentLevel + 1;

            if (newLevel >= _maxLevel)
            {
                _currentLevel = _maxLevel;
                OnUpgrade.Invoke();
                OnMaxLevelReached.Invoke();
                return;
            }

            _currentLevel = newLevel;
            OnUpgrade.Invoke();
        }
    }
}