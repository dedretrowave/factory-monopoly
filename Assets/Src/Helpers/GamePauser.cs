using System;
using DI;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Helpers
{
    public class GamePauser : MonoBehaviour
    {
        public UnityEvent OnGamePaused;
        public UnityEvent OnGameResumed;

        private void Start()
        {
            DependencyContext.Dependencies.Add(new Dependency(typeof(GamePauser), () => this));
            GameDistribution.OnResumeGame += Resume;
            GameMonetize.OnResumeGame += Resume;
            GameDistribution.OnPauseGame += Pause;
            GameMonetize.OnPauseGame += Pause;
        }

        private void OnDestroy()
        {
            GameDistribution.OnResumeGame -= Resume;
            GameDistribution.OnPauseGame -= Pause;
            GameDistribution.OnPauseGame -= Pause;
            GameMonetize.OnPauseGame -= Pause;
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