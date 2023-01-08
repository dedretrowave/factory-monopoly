using Src.Save;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Buildings.Leveling
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        
        private int _currentLevel = 0;
        private int _id;

        public UnityEvent OnUpgrade;
        public UnityEvent OnLevelZeroBypassed;
        public UnityEvent OnMaxLevelReached;

        public int CurrentLevel => _currentLevel;

        private void Start()
        {
            _id = gameObject.GetInstanceID();

            int levelFromSave = SaveSystem.Instance.GetBuildingLevel(_id);

            if (levelFromSave > 0)
            {
                OnLevelZeroBypassed.Invoke();

                for (int i = 0; i < levelFromSave; i++)
                {
                    Upgrade();
                }
            }
        }

        public void Upgrade()
        {
            if (_currentLevel == 0) OnLevelZeroBypassed.Invoke();
            
            int newLevel = _currentLevel + 1;

            if (newLevel >= _maxLevel)
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