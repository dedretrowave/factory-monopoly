using System.Collections.Generic;
using UnityEngine;

namespace Src.Helpers
{
    public class AudioOnUnfocusSwitcher : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _audios;
        
        private void OnApplicationFocus(bool hasFocus)
        {
            _audios.ForEach(audio => audio.mute = !hasFocus);
        }
    }
}