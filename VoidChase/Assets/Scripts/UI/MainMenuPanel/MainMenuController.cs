using UnityEngine;

namespace VoidChase.UI.MainMenu
{
	public class MainMenuController : BasePanelController
	{
		public void ShowLevelSelection ()
		{
			SetVisibility(false);
			UIManager.Instance.ShowPanel(PanelsNames.LevelSelection);
		}

		public void ShowOptions ()
		{
			SetVisibility(false);
			UIManager.Instance.ShowPanel(PanelsNames.Options);
		}

		public void QuitGame ()
		{
			Application.Quit();
		}
	}
}