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
        // Audioevents mit einem zugehörigen Indikator, der Abgefragt werden soll um das richtige Audio Event zu determinieren
        private Dictionary<string, ScriptableAudioEvent> _useItemAudioEvents;

        [Tooltip("The audio event that should be played when the animation event is happening")]
        [SerializeField]
        private ScriptableAudioEvent _useKeyItemAudioEvent;
        private String _keyItemtype = "Key Items";

        [SerializeField]
        private ScriptableAudioEvent _useDamageableAudioEvent;
        private String _damageableItemtype = "Damageables";

        [SerializeField]
        private ScriptableAudioEvent _usePotionAudioEvent;
        private String _potionItemtype = "Potions";

        private ScriptableAudioEvent _useOtherItemAudioEvent;

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
        public void DoUseItemSound(ScriptableObject Itemtype)
        {
            ScriptableAudioEvent value;

            // Durchsuchung des Dictonaries nach Übereinstimmung des Typen mit den Indikators
            if (_useItemAudioEvents.TryGetValue(Itemtype.name, out value))
            {
                PlaySoundForType(value);
            }
            // Absicherung für den Fall das der Itemtype kein einzigartigen Sound hat
            else
            {
                Debug.Log("There");
                PlaySoundForType(_useOtherItemAudioEvent);
            }       
        }

        private void PlaySoundForType(ScriptableAudioEvent AudioEventToPlay)
        {
            Debug.Log(AudioEventToPlay);
            AudioEventToPlay.Play(_audioSource);
        }
    }
}