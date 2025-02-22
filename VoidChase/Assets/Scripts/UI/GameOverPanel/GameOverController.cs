using VoidChase.GameLoop;

namespace VoidChase.UI.GameOver
{
	public class GameOverController : BasePanelController
	{
		public void ExitLevel ()
		{
			SetVisibility(false);
			GameLoopManager.Instance.ExitLevel();
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
			GameLoopManager.GameEnded += OnGameEnded;
		}

		private void DetachFromEvents ()
		{
			GameLoopManager.GameEnded -= OnGameEnded;
		}

		private void OnGameEnded ()
		{
			SetVisibility(true);
		}
	}
}