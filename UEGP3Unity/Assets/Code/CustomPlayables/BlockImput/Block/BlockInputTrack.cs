using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UEGP3.CustomPlayables
{
	[TrackColor(0.233f, 0435f, 0.893f)]
	[TrackClipType(typeof(BlockInputPlayableClip))]
	public class BlockInputTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			return ScriptPlayable<BlockInputPlayableMixerBehaviour>.Create(graph, inputCount);
		}
	}
}