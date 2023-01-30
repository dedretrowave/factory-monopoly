using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Src.Ads
{
    public class Ads : MonoBehaviour
    {
        [SerializeField] private float _timeSpan = 120f;

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