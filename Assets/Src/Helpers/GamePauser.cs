using System;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Helpers
{
    public class GamePauser : MonoBehaviour
    {
        private static GamePauser _instance;

        public static GamePauser Instance => _instance;

        public UnityEvent OnGamePaused;
        public UnityEvent OnGameResumed;

        private void Start()
        {
            _instance = this;
            GameDistribution.OnResumeGame += Resume;
            GameDistribution.OnPauseGame += Pause;
        }

        private void OnDisable()
        {
            GameDistribution.OnResumeGame -= Resume;
            GameDistribution.OnPauseGame -= Pause;
        }

        public void Pause()
        {
            Time.timeScale = 0;
            OnGamePaused.Invoke();
        }

        public void Resume()
        {
            Time.timeScale = 1;
            OnGameResumed.Invoke();
        }
    }
}