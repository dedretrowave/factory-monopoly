using Src.Save;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Buildings.Leveling
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        [SerializeField] private int _id;
        
        private int _currentLevel = 0;

        public UnityEvent OnUpgrade;
        public UnityEvent OnLevelZeroBypassed;
        public UnityEvent OnMaxLevelReached;

        public int CurrentLevel => _currentLevel;

        private void Start()
        {
            int levelFromSave = SaveSystem.Instance.GetBuildingLevel(_id);
            
            for (int i = 0; i < levelFromSave; i++) 
            {
                Upgrade();
            }
        }

        public void Upgrade()
        {
            if (_currentLevel == 0) OnLevelZeroBypassed.Invoke();
            
            int newLevel = _currentLevel + 1;

            if (newLevel > _maxLevel) return;

            if (newLevel == _maxLevel)
            {
                _currentLevel = _maxLevel;
                OnUpgrade.Invoke();
                OnMaxLevelReached.Invoke();
                SaveSystem.Instance.SaveBuilding(_id, _currentLevel);
                return;
            }

            _currentLevel = newLevel;
            OnUpgrade.Invoke();
            SaveSystem.Instance.SaveBuilding(_id, _currentLevel);
        }
    }
}