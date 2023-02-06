using System.Collections;
using Src.Helpers;
using UnityEngine;

namespace Src.Ads
{
    public class Ads : MonoBehaviour
    {
        [SerializeField] private float _timeSpan = 180f;
        [SerializeField] private GamePauser _pauser;

        private void Start()
        {
            StartCoroutine(ShowAdAfterTimeout());
        }

        private IEnumerator ShowAdAfterTimeout()
        {
            yield return new WaitForSeconds(_timeSpan);
            
            GameDistribution.Instance.ShowAd();

            yield return ShowAdAfterTimeout();
        }
    }
}