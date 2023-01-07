using System.Collections;
using System.Collections.Generic;
using Src.Buildings.Leveling;
using UnityEngine;

namespace Src.Helpers
{
    public class FadeAfterUpgrade : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objects;
        [SerializeField] private float _time = 5f;
        [SerializeField] private Level _level;

        private Coroutine _fadeCoroutine;

        private void Start()
        {
            _level.OnUpgrade.AddListener(StartFade);
            _level.OnMaxLevelReached.AddListener(Remove);
        }

        private void Remove()
        {
            StopCoroutine(_fadeCoroutine);
            enabled = false;
        }

        private void StartFade()
        {
            _fadeCoroutine = StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            DisableObjects();
            
            yield return new WaitForSeconds(_time);
            
            EnableObjects();
        }
        
        private void DisableObjects() => _objects.ForEach(instance => instance.SetActive(false));
        
        private void EnableObjects() => _objects.ForEach(instance => instance.SetActive(true));
    }
}