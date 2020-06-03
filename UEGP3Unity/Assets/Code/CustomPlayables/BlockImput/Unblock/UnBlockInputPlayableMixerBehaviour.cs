using UEGP3.PlayerSystem;
using UEGP3.CameraSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace UEGP3.CustomPlayables
{
	public class UnBlockInputPlayableMixerBehaviour : PlayableBehaviour
	{
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			// How many clips are on the current track?
			int inputCount = playable.GetInputCount();

			for (int i = 0; i < inputCount; i++)
			{
				// Is the current clip active?
				float inputWeight = playable.GetInputWeight(i);
				// roughly said: This "Scriptable Object" of our Template Behaviour
				ScriptPlayable<UnBlockInputPlayableBehaviour> inputPlayable = (ScriptPlayable<UnBlockInputPlayableBehaviour>) playable.GetInput(i);
                // Because we dont need the "Scriptable Object" but the actual object that we defined
                UnBlockInputPlayableBehaviour input = inputPlayable.GetBehaviour();

				// If the current clip is being played, execute logic
				if (inputWeight > 0)
                {
                    PlayerController playerController;
                    Player player;
                    ThirdPersonFreeLookCamera thirdPersonFreeLookCamera;

                    playerController = GameObject.Find("Player").GetComponent(typeof(PlayerController)) as PlayerController;
                    player = GameObject.Find("Player").GetComponent(typeof(Player)) as Player;
                    thirdPersonFreeLookCamera = GameObject.Find("FreeLookThirdPersonCamera").GetComponent(typeof(ThirdPersonFreeLookCamera)) as ThirdPersonFreeLookCamera;

                    playerController.enabled = true;
                    player.enabled = true;
                    thirdPersonFreeLookCamera.enabled = true;
                }
			}
		}
	}
}