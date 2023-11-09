namespace VoidChase.UI.GameView
{
	public class GameViewController : Controller<GameViewModel, GameViewView>
	{
		public void HandlePauseGame ()
		{
			CurrentModel.PauseGame();
		}
	}
}