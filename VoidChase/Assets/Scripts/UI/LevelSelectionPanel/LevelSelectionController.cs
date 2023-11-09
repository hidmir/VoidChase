namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionController : Controller<LevelSelectionModel, LevelSelectionView>
	{
		public void HandleSelectLevel (int levelIndex)
		{
			CurrentModel.SelectLevel(levelIndex);
		}

		public void HandleBack ()
		{
			CurrentModel.ShowMainMenu();
		}
	}
}