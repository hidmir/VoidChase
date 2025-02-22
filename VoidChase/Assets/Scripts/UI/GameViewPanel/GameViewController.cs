using UnityEngine;
using UnityEngine.UI;
using VoidChase.GameLoop;
using VoidChase.GameLoop.Pause;

namespace VoidChase.UI.GameView
{
	public class GameViewController : BasePanelController, IPausable
	{
		[field: SerializeField]
		private Button PauseButton { get; set; }

		public void PauseGame ()
		{
			PauseManager.Instance.Pause();
			UIManager.Instance.ShowPanel(PanelsNames.PauseMenu);
		}

		public void OnPause ()
		{
			PauseButton.interactable = false;
		}

		public void OnResume ()
		{
			PauseButton.interactable = true;
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void Start ()
		{
			((IPausable) this).RegisterPausable();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void OnDestroy ()
		{
			((IPausable) this).UnregisterPausable();
		}

		private void AttachToEvents ()
		{
			GameLoopManager.GameEnded += OnGameEnded;
			GameLoopManager.LevelExited += OnLevelExited;
		}

		private void DetachFromEvents ()
		{
			GameLoopManager.GameEnded -= OnGameEnded;
			GameLoopManager.LevelExited -= OnLevelExited;
		}

		private void OnGameEnded ()
		{
			SetVisibility(false);
		}

		private void OnLevelExited ()
		{
			SetVisibility(false);
		}
	}
}