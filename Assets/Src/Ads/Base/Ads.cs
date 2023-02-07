using System.Collections;
using DI;
using Src.Helpers;
using UnityEngine;
using UnityEngine.Events;

namespace Src.Ads.Base
{
    public abstract class Ads : MonoBehaviour
    {
        [SerializeField] protected float _timeSpan = 180f;

        public UnityEvent OnRewardedAdWatched;
        public UnityEvent OnRewardedAdSkipped;

        private void Start()
        {
            StartCoroutine(ShowAdAfterTimeout());
            
            DependencyContext.Dependencies.Add(new Dependency(typeof(Ads), () => this));
        }

        private IEnumerator ShowAdAfterTimeout()
        {
            yield return new WaitForSeconds(_timeSpan);
            
            ShowAd();

            yield return ShowAdAfterTimeout();
        }

        public abstract void ShowAd();
        public abstract void ShowRewardedAd();

        protected void InvokeRewardedGameWatched()
        {
            OnRewardedAdWatched.Invoke();
        }

        protected void InvokeRewardedGameSkipped()
        {
            OnRewardedAdSkipped.Invoke();
        }
    }
}