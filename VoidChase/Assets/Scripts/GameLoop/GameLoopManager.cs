using System;
using UnityEngine;
using VoidChase.GameLoop.Pause;
using VoidChase.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.GameLoop
{
	public class GameLoopManager : SingletonMonoBehaviour<GameLoopManager>
	{
		public static event Action GameEnded = delegate { };
		public static event Action LevelExited = delegate { };

		[field: SerializeField]
		private LevelProgressController BoundLevelProgressController { get; set; }

		public float GetLevelProgress => BoundLevelProgressController.GetProgress();

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

		protected override void Initialize ()
		{
			base.Initialize();
			AttachToEvents();
		}

		protected override void Shutdown ()
		{
			base.Shutdown();
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			BoundLevelProgressController.MaxProgressReached += EndGame;
		}

		private void DetachFromEvents ()
		{
			BoundLevelProgressController.MaxProgressReached -= EndGame;
		}
	}
}