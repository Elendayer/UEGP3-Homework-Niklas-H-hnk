using System;
using UnityEngine.Playables;

namespace UEGP3.CustomPlayables
{
	[Serializable]
	public class UnBlockInputPlayableBehaviour : PlayableBehaviour
	{
		// TODO 
		// InputToBlock sollte hier dann InputToUnblock heißen :) 
		// da die variable nicht benutzt wird, könnte sie allerdings auch gelöscht werden! (in beiden behaviours)
		public string InputToBlock;
	}
}