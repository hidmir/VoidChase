namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionController : Controller<LevelSelectionModel, LevelSelectionView>
	{
		public void HandleSelectLevel (int levelNumber)
		{
			CurrentModel.SelectLevel(levelNumber);
		}

		public void HandleBack ()
		{
			CurrentModel.ShowMainMenu();
		}
	}
}