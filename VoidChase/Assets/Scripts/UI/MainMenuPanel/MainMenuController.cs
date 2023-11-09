namespace VoidChase.UI.MainMenu
{
	public class MainMenuController : Controller<MainMenuModel, MainMenuView>
	{
		public void HandleStart ()
		{
			CurrentModel.ShowLevelSelection();
		}

		public void HandleOptions ()
		{
			CurrentModel.ShowOptions();
		}

		public void HandleQuit ()
		{
			CurrentModel.QuitGame();
		}
	}
}