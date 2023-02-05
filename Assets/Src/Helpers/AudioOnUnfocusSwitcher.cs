using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Src.Helpers
{
    public class AudioOnUnfocusSwitcher : MonoBehaviour
    {
        [DllImport("__Internal")] private static extern void SubscribeForVisibilityChange();
        
        [SerializeField] private List<AudioSource> _audios;

        private void Start()
        {
#if !UNITY_EDITOR
            SubscribeForVisibilityChange();      
#endif
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

        private void Switch(bool value)
        {
            _audios.ForEach(audio => audio.mute = value);
        }
    }
}