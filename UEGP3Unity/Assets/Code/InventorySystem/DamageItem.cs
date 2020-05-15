using UnityEngine;

namespace UEGP3.InventorySystem
{
	[CreateAssetMenu(fileName = "New DamageItem", menuName = "UEGP3/Inventory System/New Damage Item")]
	public class DamageItem : Item
	{
		[SerializeField] private float _damage = 5.0f;
		
		public override void UseItem()
		{
			Debug.Log($"Inflict {_damage} damage!");
		}
	}
}