using System.Collections;
using System.Collections.Generic;
using UEGP3.PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UEGP3.InventorySystem
{
    public class InventoryBag : MonoBehaviour
    {
        [SerializeField]
        private BagSciptableObject _bag;

        [SerializeField]
        private GameObject _slot;

        public GameObject[] Slots;


        public BagSciptableObject Bag  => _bag;
        public GameObject Slot => _slot;

        GameObject Slot_;

        private void Awake()
        {
            SetupUIBags();
        }

        public void SetupUIBags()
        {
            tag = "Bag";

            for (int i = 0; i < _bag.BagSize; i++)
            {
                Slot_ = (GameObject)Instantiate(_slot, transform);
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                Slots[i] = transform.GetChild(i).gameObject;
            }         
        }
    }
}
