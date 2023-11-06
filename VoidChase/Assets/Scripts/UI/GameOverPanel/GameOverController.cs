namespace VoidChase.UI.GameOver
{
	public class GameOverController : Controller<GameOverModel, GameOverView>
	{
		public void HandleContinue ()
		{
			CurrentModel.LoadMainMenu();
			CurrentView.SetContentState(false);
		}
	}
}