using System;
using UnityEngine;
using VoidChase.GameLoop.Pause;
using VoidChase.SceneManagement;
using VoidChase.Score;
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
		public bool IsEndedWithSuccess { get; private set; }

		public void EndGameWithSuccess ()
		{
			IsEndedWithSuccess = true;
			EndGame();
		}

		public void EndGameWithFailure ()
		{
			IsEndedWithSuccess = false;
			EndGame();
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

		private void EndGame ()
		{
			PauseManager.Instance.Pause();
			ScoreManager.Instance.AttemptSaveScore();
			GameEnded.Invoke();
		}

		private void AttachToEvents ()
		{
			BoundLevelProgressController.MaxProgressReached += EndGameWithSuccess;
		}

		private void DetachFromEvents ()
		{
			BoundLevelProgressController.MaxProgressReached -= EndGameWithSuccess;
		}
	}
}