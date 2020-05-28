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
                // TODO
                // it is a good idea to store such references in private variables. GetComponent is quite performance heavy 
                // and it can cause lag spikes. We could instead save the PlayerInventory in a variable here in the UI for later
                // access
                _player.GetComponent<Player>().PlayerInventory.ValidateInventory();
            }

            // TODO 
            // Same as with the other keycode usage
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                // TODO 
                // this can be simplified to: _inventory.SetActive(!_inventory.active)
                // the "!" inverts the value in _inventory.active, so if it equals true, we return false and vice versa. 
                // This will keep your code more readable. Another note: if (aBool == true) / if (aBool == false) is the 
                // same as writing if (aBool) / if (!aBool) and generally this is the preferred usage.
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
