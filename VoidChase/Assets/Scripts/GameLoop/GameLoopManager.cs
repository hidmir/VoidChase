using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VoidChase.PauseManagement;
using VoidChase.Player;
using VoidChase.SceneManagement;
using VoidChase.Score;
using VoidChase.Utilities;

namespace VoidChase.GameLoop
{
	public class GameLoopManager : SingletonMonoBehaviour<GameLoopManager>
	{
		public static event Action GameEnded = delegate { };
		public static event Action LevelExited = delegate { };

		[field: Header(InspectorNames.REFERENCES_NAME)]
		[field: SerializeField]
		private LevelProgressController BoundLevelProgressController { get; set; }
		[field: SerializeField]
		private List<GameObject> ObjectsToHideOnGameEnd { get; set; }

		[field: Header(InspectorNames.SETTINGS_NAME)]
		[field: SerializeField]
		private float PlayerVictoryAnimationTime { get; set; } = 3.0f;
		[field: SerializeField]
		private float PlayerVictoryAnimationDistance { get; set; } = 20.0f;

		public float GetLevelProgress => BoundLevelProgressController.GetProgress();
		public bool IsEndedWithSuccess { get; private set; }
		private PlayerReferences CurrentPlayerReferences => PlayerReferences.Instance;

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

		private void EndGameWithSuccess ()
		{
			PauseManager.Instance.Pause();
			StartCoroutine(PlayerVictoryProcess());
		}

		private void EndGameWithFailure ()
		{
			PauseManager.Instance.Pause();
			StartCoroutine(PlayerDestructionProcess());
		}

		private IEnumerator PlayerVictoryProcess ()
		{
			Transform playerModel = CurrentPlayerReferences.PlayerModel.transform;
			CurrentPlayerReferences.ThrusterFlameImage.forceRenderingOff = false;

			Tween tween = playerModel
				.DOMoveY(playerModel.position.y + PlayerVictoryAnimationDistance, PlayerVictoryAnimationTime)
				.SetEase(Ease.Linear);

			while (tween.IsActive() && tween.IsPlaying())
			{
				yield return null;
			}

			IsEndedWithSuccess = true;
			EndGame();
		}

		private IEnumerator PlayerDestructionProcess ()
		{
			CurrentPlayerReferences.PlayerModel.SetActive(false);
			ParticleSystem playerDestructionEffect = CurrentPlayerReferences.DestructionEffect;
			playerDestructionEffect.Play();
			CurrentPlayerReferences.DestructionAudio.Play();

			yield return new WaitWhile(IsDestructionEffectPlaying);

			IsEndedWithSuccess = false;
			EndGame();

			bool IsDestructionEffectPlaying ()
			{
				return playerDestructionEffect.isPlaying;
			}
		}

		private void EndGame ()
		{
			ScoreManager.Instance.AttemptSaveScore();

			foreach (GameObject @object in ObjectsToHideOnGameEnd)
			{
				@object.SetActive(false);
			}

			GameEnded.Invoke();
		}

		private void AttachToEvents ()
		{
			BoundLevelProgressController.MaxProgressReached += EndGameWithSuccess;
			PlayerHealthMonitor.PlayerDestroyed += EndGameWithFailure;
		}

		private void DetachFromEvents ()
		{
			BoundLevelProgressController.MaxProgressReached -= EndGameWithSuccess;
			PlayerHealthMonitor.PlayerDestroyed -= EndGameWithFailure;
		}
	}
}