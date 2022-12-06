using UnityEngine;
using UnityEngine.Events;

namespace Src.Leveling
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        
        private int _currentLevel = 0;

        public UnityEvent<int> OnUpgrade;
        public UnityEvent OnLevelZeroBypassed;

        public int CurrentLevel => _currentLevel;

        public void Upgrade()
        {
            if (_currentLevel == 0) OnLevelZeroBypassed.Invoke();
            
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