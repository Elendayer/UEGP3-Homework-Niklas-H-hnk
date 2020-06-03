using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UEGP3.CustomPlayables
{
	[Serializable]
	public class UnBlockInputPlayableClip : PlayableAsset, ITimelineClipAsset
	{
		public UnBlockInputPlayableBehaviour template = new UnBlockInputPlayableBehaviour();
		
		public ClipCaps clipCaps => ClipCaps.None;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<UnBlockInputPlayableBehaviour>.Create(graph, template);
			return playable;
		}
	}
}