using VoidChase.SceneManagement;

namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionModel : Model<LevelSelectionView>
	{
		public void LoadLevel (int index)
		{
			SceneLoader.Instance.LoadLevelScene(index);
		}

		public void ShowMainMenu ()
		{
			UIManager.Instance.ShowPanel(PanelType.MAIN_MENU);
		}

		public void HideLevelSelection ()
		{
			UIManager.Instance.HidePanel(PanelType.LEVEL_SELECTION);
		}
	}
}