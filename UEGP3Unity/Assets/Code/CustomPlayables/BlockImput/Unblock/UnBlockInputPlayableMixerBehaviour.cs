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

                    // TODO
                    // das Gleiche kannst du auch so erzielen, um dir den cast zu sparen:
                    // playerController = GameObject.Find("Player").GetComponent<PlayerController>();
                    // Generell würde ich dir aber empfehlen die Calls von Find und GetComponent so gut es geht zu vermeiden, wenn wir andere Möglichkeiten haben.
                    // Das liegt einfach daran, dass dies sehr performance intensive Aufrufe sind. Wenn wir das ab und zu machen ist das natürlich okay. Im Falle von timeline
                    // haben wir allerdings das Problem, dass jeden Frame den die Timeline abspielt und diesen Track beinhaltet die Logik in ProcessFrame() ausgeführt wird.
                    // Durch das if (inputWeight > 0) reduzieren wir die Calls immerhin auf aktive Clips, aber sobald ein Clip aktiv ist, wird trotzdem jeden Frame diese Logik ausgeführt.
                    // Das können wir uns sparen, in dem wir einmal die Komponenten suchen und cachen. Danahc können wir jeweils auf sie zugreifen.
                    // Insgesamt ist die Lösung so in Ordnung, aber wir können sie noch etwas vereinfachen und dafür sorgen, dass wir nicht bei jeder Änderung im Input-System hier Code hinzufügen
                    // und warten müssen: Wir können dem Player ein Flag "IsInputBlocked" geben, welches wir in den (un)block clips ansprechen können. Der Pseudo-Code wäre dann:
                    // if (clip.IsRunning) Find(Player).IsInputBlocked = true/false, je nach clip. Code der den Input des Spielers fordert kann dann fragen, ob Player.IsInputBlocked == true/false
                    // und basierend darauf handeln. Das erzielt den glecihen Effekt, ist aber etwas eleganter, weil wir diesen Clip nicht warten müssen, sondern einfahc da wo der Input eh benutzt wird abfragen können.
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