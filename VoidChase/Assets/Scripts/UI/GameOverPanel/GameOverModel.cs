using VoidChase.GameManagement;

namespace VoidChase.UI.GameOver
{
	public class GameOverModel : Model<GameOverView>
	{
		public void ExitLevel ()
		{
			CurrentView.SetContentState(false);
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
			CurrentView.SetContentState(true);
		}
	}
}