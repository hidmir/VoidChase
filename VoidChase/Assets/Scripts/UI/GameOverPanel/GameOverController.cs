namespace VoidChase.UI.GameOver
{
	public class GameOverController : Controller<GameOverModel, GameOverView>
	{
		public void HandleContinue ()
		{
			CurrentModel.ExitLevel();
		}
	}
}