using UnityEngine;
using UnityEngine.UI;
using VoidChase.GameManagement;

namespace VoidChase.UI.GameView
{
	public class GameViewController : BasePanelController
	{
		[field: SerializeField]
		private Button PauseButton { get; set; }

		public void PauseGame ()
		{
			GameManager.Instance.PauseGame();
			UIManager.Instance.ShowPanel(PanelsNames.PauseMenu);
		}

		private void OnEnable ()
		{
			AttachToEvents();
		}

		private void OnDisable ()
		{
			DetachFromEvents();
		}

		private void AttachToEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged += OnIsGamePausedValueChanged;
			GameGlobalActions.EndGame += OnEndGame;
			GameGlobalActions.ExitLevel += OnExitLevel;
		}

		private void DetachFromEvents ()
		{
			GameGlobalVariables.IsGamePaused.CurrentValueChanged -= OnIsGamePausedValueChanged;
			GameGlobalActions.EndGame -= OnEndGame;
			GameGlobalActions.ExitLevel -= OnExitLevel;
		}

		private void OnIsGamePausedValueChanged (bool isPaused)
		{
			SetPauseButtonInteractionsState(!isPaused);
		}

		private void OnEndGame ()
		{
			SetVisibility(false);
		}

		private void OnExitLevel ()
		{
			SetVisibility(false);
		}

		private void SetPauseButtonInteractionsState (bool isEnabled)
		{
			PauseButton.interactable = isEnabled;
		}
	}
}