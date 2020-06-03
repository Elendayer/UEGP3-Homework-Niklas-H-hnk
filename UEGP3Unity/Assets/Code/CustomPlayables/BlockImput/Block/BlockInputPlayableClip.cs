using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UEGP3.CustomPlayables
{
	[Serializable]
	public class BlockInputPlayableClip : PlayableAsset, ITimelineClipAsset
	{
		public BlockInputPlayableBehaviour template = new BlockInputPlayableBehaviour();
		
		public ClipCaps clipCaps => ClipCaps.None;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<BlockInputPlayableBehaviour>.Create(graph, template);
			return playable;
		}
	}
}