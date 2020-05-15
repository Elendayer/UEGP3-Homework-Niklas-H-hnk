using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UEGP3.InventorySystem
{
    [CreateAssetMenu(menuName = "UEGP3/Inventory System/New Bag", fileName = "New Bag")]
    public class BagSciptableObject : ScriptableObject
    {
        [SerializeField]
        private string _bagName;
        [SerializeField]
        private int _bagSize;
        [SerializeField]
        private string _bagType;

        public int BagSize => _bagSize;

        public string BagType
        {
            get => _bagType;
            set => _bagType = value;
        }

    }
}