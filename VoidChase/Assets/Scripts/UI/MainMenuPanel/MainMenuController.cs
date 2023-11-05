namespace VoidChase.UI.MainMenu
{
	public class MainMenuController : Controller<MainMenuModel, MainMenuView>
	{
		public void HandleStart ()
		{
			CurrentModel.HideMainMenu();
			CurrentModel.ShowLevelSelection();
		}

		public void HandleOptions ()
		{
			CurrentModel.HideMainMenu();
			CurrentModel.ShowOptions();
		}

		public void HandleQuit ()
		{
			CurrentModel.QuitGame();
		}
	}
}