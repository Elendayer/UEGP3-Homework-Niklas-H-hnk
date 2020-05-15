using System;
using System.Collections.Generic;
using UnityEngine;

namespace UEGP3.InventorySystem
{
    [CreateAssetMenu(menuName = "UEGP3/Inventory System/New Inventory", fileName = "New Inventory")]
    public class Inventory : ScriptableObject
    {
        [Tooltip("Maximum amount of items that can be stored in the inventory")]
        [SerializeField]
        private int _maximumSize = 5;

        private Dictionary<Item, int> _inventoryItems = new Dictionary<Item, int>();
        private Item _quickAccesItem;

        private GameObject[] _bags;

        private GameObject[] _potionBags;
        private GameObject[] _potionSlots;
        private int _potionSlotCount;

        private GameObject[] _granadeBags;
        private GameObject[] _granadeSlots;
        private int _granadeSlotCount;

        private GameObject[] _keyBags;
        private GameObject[] _keySlots;
        private int _keySlotCount;

        private void Awake()
        {
            SetupUIInventory();
        }

        public void SetupUIInventory()
        {
            _bags = GameObject.FindGameObjectsWithTag("Bag");

            for (int i = 0; i < _bags.Length; i++)
            {
                if (_bags[i].GetComponent<InventoryBag>().Bag.BagType == "Potion")
                {
                    _potionBags[_potionBags.Length] = _bags[i];
                }
                if (_bags[i].GetComponent<InventoryBag>().Bag.BagType == "Granade")
                {
                    _granadeBags[_granadeBags.Length] = _bags[i];
                }
                if (_bags[i].GetComponent<InventoryBag>().Bag.BagType == "Key")
                {
                    _keyBags[_granadeBags.Length] = _bags[i];
                }
            }

            for (int i = 0; i < _potionSlots.Length; i++)
            {
                _potionSlots[i].GetComponent<InventorySlot>().TagingSlots();
            }
            for (int i = 0; i < _granadeSlots.Length; i++)
            {
                _granadeSlots[i].GetComponent<InventorySlot>().TagingSlots();
            }
            for (int i = 0; i < _keySlots.Length; i++)
            {
                _keySlots[i].GetComponent<InventorySlot>().TagingSlots();
            }
        }

        void MakeSlotArray()
        {
            _potionSlots = GameObject.FindGameObjectsWithTag("PotionSlot");           
            _granadeSlots = GameObject.FindGameObjectsWithTag("GranadeSlot");
            _keySlots = GameObject.FindGameObjectsWithTag("KeySlot");
        }

        public void ValidateInventory()
        {

            MakeSlotArray();

                foreach (KeyValuePair<Item, int> entry in _inventoryItems)
                {
                    if (entry.Key.ItemType == "Potion")
                    {
                        _potionSlots[0].GetComponent<InventorySlot>().Item = entry.Key;
                        _potionSlots[0].GetComponent<InventorySlot>().ItemCount = entry.Value;
                    }

                    if (entry.Key.ItemType == "Granade")
                    {
                        _granadeSlots[0].GetComponent<InventorySlot>().Item = entry.Key;
                        _granadeSlots[0].GetComponent<InventorySlot>().ItemCount = entry.Value;
                    }

                    if (entry.Key.ItemType == "Key")
                    {
                        _keySlots[0].GetComponent<InventorySlot>().Item = entry.Key;
                        _keySlots[0].GetComponent<InventorySlot>().ItemCount = entry.Value;
                    }
                }
        }      
      
        // _bags[i].GetComponent<InventoryBag>().Slots[i]

        /// <summary>
        /// Prints the inventory to the console.
        /// </summary>
        public void ShowInventory()
        {
            Debug.Log(this);
        }

        /// <summary>
        /// Tries to add a given item to the inventory
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>A bool whether the adding process succeeded</returns>
        public bool TryAddItem(Item item)
        {
            bool success = false;
            // Item is not yet in inventory, add it
            if (!_inventoryItems.ContainsKey(item))
            {
                // only add items if inventory is not full
                if (_inventoryItems.Count >= _maximumSize)
                {
                    return false;
                }

                _inventoryItems.Add(item, 1);
                success = true;
            }
            // Item is already in inventory, stack it up if possible
            else
            {
                // Only items that are not unique can be stacked
                if (!item.IsUnique)
                {
                    _inventoryItems[item]++;
                    success = true;
                }
            }

            // if item was added successfully and quick access is empty, add it to the quick access.
            if (success && (_quickAccesItem == null))
            {
                AddToQuickAccess(item);
            }

            return success;
        }

        public void UseItem(Item item)
        {
            // Item can only be used if it is in the inventory
            if (!_inventoryItems.ContainsKey(item))
            {
                return;
            }

            // Use the item
            item.UseItem();

            // if consumed upon use, decrease count
            if (item.ConsumeUponUse)
            {
                _inventoryItems[item]--;
            }

            // if no longer in inventory, because count == 0, remove it
            if (_inventoryItems[item] == 0)
            {
                RemoveItem(item);
            }
        }

        public void UseQuickAccessItem()
        {
            // only execute if quick access holds an item
            if (_quickAccesItem == null)
            {
                return;
            }

            // Use item
            UseItem(_quickAccesItem);

            // if item is no longer in the inventory, remove from quick access
            if (!_inventoryItems.ContainsKey(_quickAccesItem))
            {
                RemoveFromQuickAccess();
            }
        }

        /// <summary>
        /// Removes the given item from the inventory
        /// </summary>
        /// <param name="item">The item to be removed</param>
        private void RemoveItem(Item item)
        {
            _inventoryItems.Remove(item);
        }

        /// <summary>
        /// Add the given item to the quick access.
        /// </summary>
        /// <param name="item"></param>
        private void AddToQuickAccess(Item item)
        {
            _quickAccesItem = item;
        }

        /// <summary>
        /// Removes the current item from the quick access.
        /// </summary>
        private void RemoveFromQuickAccess()
        {
            _quickAccesItem = null;
        }

        public override string ToString()
        {
            // "String-Interpolation": $ before a string "" allows us to use variables in {} 
            // inventory = "Inventory " + name + " contains:\r\n" is the same as the line below, but nicer! :) 
            string inventory = $"Inventory {name} contains:\r\n";

            foreach (KeyValuePair<Item, int> inventoryItem in _inventoryItems)
            {
                inventory += $"[{inventoryItem.Key.ItemName} - {inventoryItem.Value}]\r\n";
            }

            return inventory;
        }
    }
}