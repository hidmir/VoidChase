using System;
using VoidChase.GameLoop.Pause;
using VoidChase.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.GameLoop
{
	public class GameLoopManager : SingletonMonoBehaviour<GameLoopManager>
	{
		public static event Action GameEnded = delegate { };
		public static event Action LevelExited = delegate { };

		public void EndGame ()
		{
			PauseManager.Instance.Pause();
			GameEnded.Invoke();
		}

		public void ExitLevel ()
		{
			LevelExited.Invoke();
			PauseManager.Instance.Resume();
			SceneLoader.Instance.LoadMainMenuScene();
		}
	}
}