namespace VoidChase.UI.PauseMenu
{
	public class PauseMenuController : Controller<PauseMenuModel, PauseMenuView>
	{
		public void HandleContinue ()
		{
			CurrentModel.UnPauseGame();
		}

		public void HandleQuit ()
		{
			CurrentModel.ExitLevel();
		}
	}
}