using VoidChase.GameManagement;

namespace VoidChase.UI.GameOver
{
	public class GameOverController : BasePanelController
	{
		public void ExitLevel ()
		{
			SetVisibility(false);
			GameManager.Instance.ExitLevel();
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
			GameGlobalActions.EndGame += OnEndGame;
		}

		private void DetachFromEvents ()
		{
			GameGlobalActions.EndGame -= OnEndGame;
		}

		private void OnEndGame ()
		{
			SetVisibility(true);
		}
	}
}