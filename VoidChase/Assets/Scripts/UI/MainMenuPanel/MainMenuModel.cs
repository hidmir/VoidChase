using UnityEngine;
using VoidChase.Utilities;

namespace VoidChase.UI.MainMenu
{
	public class MainMenuModel : Model<MainMenuView>
	{
		[Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)] 
		[SerializeField] private string levelSelectionPanelName;
		[Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)] 
		[SerializeField] private string optionsPanelName;

		public void ShowLevelSelection ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(levelSelectionPanelName);
		}
		
		public void ShowOptions ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(optionsPanelName);
		}

		public void QuitGame ()
		{
			Application.Quit();
		}
	}
}