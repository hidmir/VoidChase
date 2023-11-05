using UnityEngine;

namespace VoidChase.UI.MainMenu
{
	public class MainMenuModel : Model<MainMenuView>
	{
		public void ShowLevelSelection ()
		{
			UIManager.Instance.ShowPanel(PanelType.LEVEL_SELECTION);
		}
		
		public void ShowOptions ()
		{
			UIManager.Instance.ShowPanel(PanelType.OPTIONS);
		}

		public void HideMainMenu ()
		{
			UIManager.Instance.HidePanel(PanelType.MAIN_MENU);
		}

		public void QuitGame ()
		{
			Application.Quit();
		}
	}
}