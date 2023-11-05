namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionController : Controller<LevelSelectionModel, LevelSelectionView>
	{
		public void HandleSelectLevel (int levelIndex)
		{
			CurrentModel.HideLevelSelection();
			CurrentModel.LoadLevel(levelIndex);
		}

		public void HandleBack ()
		{
			CurrentModel.HideLevelSelection();
			CurrentModel.ShowMainMenu();
		}
	}
}