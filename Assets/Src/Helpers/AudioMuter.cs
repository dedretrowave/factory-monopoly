using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Src.Helpers
{
    public class AudioMuter : MonoBehaviour
    {
        [DllImport("__Internal")] private static extern void SubscribeForVisibilityChange();
        
        [SerializeField] private List<AudioSource> _audios;
        [SerializeField] private GamePauser _pauser;

        private void Awake()
        {
#if !UNITY_EDITOR
            SubscribeForVisibilityChange();      
#endif
            
            _pauser.OnGamePaused.AddListener(Disable);
            _pauser.OnGameResumed.AddListener(Enable);
        }

        private void OnVisibilityChange(string visibilityState)
        {
            Switch(visibilityState.Equals("visible"));
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            Switch(!hasFocus);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            Switch(!pauseStatus);
        }

        private void Disable()
        {
            Switch(true);
        }

        private void Enable()
        {
            Switch(false);
        }

        private void Switch(bool value)
        {
            _audios.ForEach(audio => audio.mute = value);
        }
    }
}