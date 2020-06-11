using System;
using UEGP3.Core;
using UnityEngine;
using UnityEngine.Animations;

namespace UEGP3.PlayerSystem
{
	[RequireComponent(typeof(AudioSource))]
	public class FootStepAudioHandler : MonoBehaviour
	{
		private ScriptableAudioEvent _footstepAudioEvent;

		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		// Called as an animation event
		private void DoFootStepSound(AnimationEvent animationEvent)
		{
            ScriptableAudioEvent _footstepAudioEvent = animationEvent.objectReferenceParameter as ScriptableAudioEvent;
            // TODO 
            // an dieser Stelle wäre ein Null-check praktisch, falls es kein footstepAudioEvent gibt:
            // if (_footstepAudioEvent == null)
            // {
            //  	return;
            // }
            _footstepAudioEvent.Play(_audioSource);
		}
	}
}