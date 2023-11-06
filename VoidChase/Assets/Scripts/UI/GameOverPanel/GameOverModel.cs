using VoidChase.GameManagement;
using VoidChase.SceneManagement;

namespace VoidChase.UI.GameOver
{
	public class GameOverModel : Model<GameOverView>
	{
		public void LoadMainMenu ()
		{
			SceneLoader.Instance.LoadMainMenuScene();
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