using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UEGP3.InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        private Item _item;
        [SerializeField]
        private Text _itemText;

        [SerializeField]
        private Text _itemCountText;
        [SerializeField]
        private Button _button;
        private GameObject _bag;
        private BagSciptableObject _bagType;

        private int _itemCount;

        public int ItemCount { get => _itemCount; set => _itemCount = value; }
        public Item Item { get => _item; set => _item = value; }

        private void Awake()
        {
            _bagType = transform.parent.gameObject.GetComponent<InventoryBag>().Bag;
            _bag = this.transform.parent.gameObject;
         //   _itemText = GetComponentInChildren<Text>();
         //   _button = GetComponentInChildren<Button>();

            _button.onClick.AddListener(UseItem);

            TagingSlots();
        }

        public void TagingSlots()
        {
            string tagString = _bagType.BagType + "Slot";

            tag = tagString;
        }

        // TODO
        // instead of updating each frame, it is better to write a method for updating the slot
        // Said method can simply set the values, once they change. This will save valuable CPU cycles
        private void Update()
        {
            DisplayItem();
        }

        void DisplayItem()
        {
            if(_item != null)
            {

                _itemCountText.text =

                    $"{_itemCount}";

                _button.gameObject.GetComponent<Image>().sprite =  _item.ItemSprite;

                _itemText.text =

                    $"{_item.ItemName}" +

                    $" {_item.Description}";
            }
        }

        // TODO
        // uses item, but doesnt respect inventory count etc.
        void UseItem()
        {
            _item.UseItem();
        }
    }
}
