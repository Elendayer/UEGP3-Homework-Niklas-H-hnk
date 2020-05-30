using System;
using System.Collections;
using System.Collections.Generic;
using UEGP3.Core;
using UnityEngine;

namespace UEGP3.InventorySystem.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UseItemAudioHandler : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Called as an animation event
        public void DoUseItemSound(Item Item)
        {
            Item.ItemAudio.Play(_audioSource);
        }
    }
}