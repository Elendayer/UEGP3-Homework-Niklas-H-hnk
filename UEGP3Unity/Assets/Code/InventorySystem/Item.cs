using UnityEngine;

namespace UEGP3.InventorySystem
{
	public abstract class Item : ScriptableObject
	{
		[Tooltip("The name of the item")] [SerializeField]
		protected string _itemName;
		[Tooltip("Short description of the item, shown to the player")] [SerializeField]
		private string _description;
		[Tooltip("A small icon of the item")] [SerializeField]
		private Sprite _itemSprite;
		[Tooltip("Is the item being consumed after usage?")] [SerializeField]
		private bool _consumeUponUse;
		[Tooltip("A unique item can not be stacked in the players inventory")] [SerializeField]
		private bool _isUnique;
        [SerializeField]
        private GameObject _itemMesh;
        [SerializeField]
        private string _itemType;
		
		/* // C# Auto-Property
		public bool ConsumeUponuse { get; set; }
		// C# Property: We can define more logic in get & set
		public Sprite ItemSprite {
			get
			{
				if (_isUnique)
				{
					return _uniqueSprite;
				}
				else
				{
					return _normalSprite;
				}
			}
			set
			{
				if (_consumeUponUse)
				{
					// Do some more logic
				}
				_itemSprite = value;
			}
		}
		*/
		
		// public getter only - "readonly"
		public bool IsUnique => _isUnique;
		public bool ConsumeUponUse => _consumeUponUse;
        public string Description => _description;
        public string ItemName => _itemName;
        public GameObject ItemMesh => _itemMesh;
        public string ItemType => _itemType;
        public Sprite ItemSprite => _itemSprite;

        /// <summary>
        /// Uses the item and executes its effect.
        /// </summary>
        public abstract void UseItem();
	}
}