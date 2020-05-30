using System;
using System.Collections;
using System.Collections.Generic;
using UEGP3.Core;
using UnityEngine;

namespace UEGP3.PlayerSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class UseItemAudioHandler : MonoBehaviour
    {
        // Audioevents mit einem zugehörigen Indikator, der Abgefragt werden soll um das richtige Audio Event zu determinieren
        private Dictionary<string, ScriptableAudioEvent> _useItemAudioEvents;

        [Tooltip("The audio event that should be played when the animation event is happening")]
        [SerializeField]
        private ScriptableAudioEvent _useKeyItemAudioEvent;
        String _keyItemtype = "Key Items";

        [SerializeField]
        private ScriptableAudioEvent _useDamageableAudioEvent;
        String _damageableItemtype = "Damageables";

        [SerializeField]
        private ScriptableAudioEvent _usePotionAudioEvent;
        String _potionItemtype = "Potions";

        private int Itemtypes = 3;

        private AudioSource _audioSource;

        private void Awake()
        {
            _useItemAudioEvents = new Dictionary<string, ScriptableAudioEvent>();

            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            // Aufbau des Dictonaries mit dem Indicator und dem dazugehörigen AudioEvent
            _useItemAudioEvents.Add(_keyItemtype, _useKeyItemAudioEvent);
            _useItemAudioEvents.Add(_damageableItemtype, _useDamageableAudioEvent);
            _useItemAudioEvents.Add(_potionItemtype, _usePotionAudioEvent);
        }

        // Called as an animation event
        private void DoUseItemSound(ScriptableObject Itemtype)
        {
            // Durchsuchung des Dictonaries nach Übereinstimmung des Typen mit den indikators
            foreach (var element in _useItemAudioEvents)
            {
                string Indicator = element.Key;
                if (Indicator == Itemtype.name)
                {
                    PlaySoundForType(element.Value);
                }
            }
        }

        private void PlaySoundForType(ScriptableAudioEvent AudioEventToPlay)
        {
            AudioEventToPlay.Play(_audioSource);
        }
    }
}