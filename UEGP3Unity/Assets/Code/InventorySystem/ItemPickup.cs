using System;
using UEGP3.Core;
using UnityEngine;

namespace UEGP3.InventorySystem
{
	[RequireComponent(typeof(SphereCollider))]
	public class ItemPickup : MonoBehaviour, ICollectible
	{
		[Tooltip("The scriptable object of the item to be picked up.")] [SerializeField]
		private Item _itemToPickup;
		[Tooltip("Range in which the pick up is performed.")] [SerializeField] 
		private float _pickupRange;
		
		private SphereCollider _pickupCollider;

        GameObject PickupGraphicsObject;

        private void Awake()
		{
			// Get collider on same object
			_pickupCollider = GetComponent<SphereCollider>();

            // Ensure collider values are set accordingly
            _pickupCollider.radius = _pickupRange;
			_pickupCollider.isTrigger = true;

            PickupGraphicsObject = (GameObject)Instantiate(_itemToPickup.ItemMesh, transform);

        }

		public void Collect(Inventory inventory)
		{
			// Add item to inventory
			bool wasPickedUp = inventory.TryAddItem(_itemToPickup);

			// Destroy the pickup once the object has been successfully picked up
			if (wasPickedUp)
			{
				Destroy(gameObject);
			}
		}
		
#if UNITY_EDITOR
		private void OnValidate()
		{
			if (!_pickupCollider)
			{
				_pickupCollider = GetComponent<SphereCollider>();
			}
			
			// Ensure radius is set correctly
			_pickupCollider.radius = _pickupRange;
		}
#endif
	}
}