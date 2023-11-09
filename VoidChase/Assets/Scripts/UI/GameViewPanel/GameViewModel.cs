using VoidChase.GameManagement;

namespace VoidChase.UI.GameView
{
	public class GameViewModel : Model<GameViewView>
	{
		public void PauseGame ()
		{
			GameManager.Instance.PauseGame();
			UIManager.Instance.ShowPanel(PanelType.PAUSE_MENU);
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
			CurrentView.SetPauseButtonInteractionsState(!isPaused);
		}

		private void OnEndGame ()
		{
			CurrentView.SetContentState(false);
		}

		private void OnExitLevel ()
		{
			CurrentView.SetContentState(false);
		}
	}
}