using VoidChase.SceneManagement;

namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionController : BasePanelController
	{
		public void SelectLevel (int number)
		{
			SetVisibility(false);
			SceneLoader.Instance.LoadLevelScene(number);
		}

		public void ShowMainMenu ()
		{
			SetVisibility(false);
			UIManager.Instance.ShowPanel(PanelsNames.MainMenu);
		}
	}
}