using VoidChase.SceneManagement;

namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionModel : Model<LevelSelectionView>
	{
		public void SelectLevel (int index)
		{
			CurrentView.SetContentState(false);
			SceneLoader.Instance.LoadLevelScene(index);
		}

		public void ShowMainMenu ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(PanelType.MAIN_MENU);
		}
	}
}