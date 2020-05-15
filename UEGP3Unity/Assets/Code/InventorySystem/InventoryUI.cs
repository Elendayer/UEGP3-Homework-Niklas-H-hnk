using System;
using System.Collections;
using System.Collections.Generic;
using UEGP3.PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UEGP3.InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _iventory;
        [SerializeField]
        private GameObject _layouter;
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private GameObject[] _bagsToSpawn;

        private GameObject Bag;


        private void Awake()
        {          
            for (int i = 0; i < _bagsToSpawn.Length; i++)
            {
                GameObject Bag = (GameObject)Instantiate(_bagsToSpawn[i], _layouter.transform);
            }
        }

        private void Start()
        {
            _iventory.SetActive(false);
        }

        void Update()
        {
            if (_iventory.active == true)
            {
                _player.GetComponent<Player>().PlayerInventory.ValidateInventory();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (_iventory.active == false)
                {                 
                    _iventory.SetActive(true);
                    return;
                }
                if (_iventory.active == true)
                {
                    _iventory.SetActive(false);
                    return;
                }
            }
        }
    }
}
