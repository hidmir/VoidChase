using UnityEngine;

namespace VoidChase.UI.MainMenu
{
	public class MainMenuModel : Model<MainMenuView>
	{
		public void ShowLevelSelection ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(PanelType.LEVEL_SELECTION);
		}
		
		public void ShowOptions ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(PanelType.OPTIONS);
		}

		public void QuitGame ()
		{
			Application.Quit();
		}
	}
}