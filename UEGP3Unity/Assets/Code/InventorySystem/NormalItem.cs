using UnityEngine;

namespace UEGP3.InventorySystem
{
	[CreateAssetMenu(fileName = "New Item", menuName = "UEGP3/Inventory System/New Item")]
	public class NormalItem : Item
	{
		public override void UseItem()
		{
			Debug.Log($"Using {_itemName} item.");
		}
	}
}