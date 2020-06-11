using System.Collections;
using System.Collections.Generic;
using UEGP3.Core;
using UnityEngine;

namespace UEGP3.PlayerSystem
{
    // Good job. Adde ruhig auch für weniger komplizierte Scripts wie dieses Kommentare + Tooltips. Ist etwas arbeit, gibt aber Punkte und macht Code auf lange Sicht übersichtlicher! ;)
    [RequireComponent(typeof(AudioSource))]
    public class JumpAudioHandler : MonoBehaviour
    {
        [Tooltip("The audio event that should be played when the animation event is happening")]
        [SerializeField]
        private ScriptableAudioEvent _jumpingAudioEvent;
        [SerializeField]
        private ScriptableAudioEvent _landingAudioEvent;

        private AudioSource _audioSource;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Called as an animation event
        private void DoJumpSound()
        {
            _jumpingAudioEvent.Play(_audioSource);
        }
        private void DoLandSound()
        {
            _landingAudioEvent.Play(_audioSource);
        }
    }
}