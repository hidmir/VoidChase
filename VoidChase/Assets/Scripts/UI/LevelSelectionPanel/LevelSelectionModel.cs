using UnityEngine;
using VoidChase.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.UI.LevelSelection
{
	public class LevelSelectionModel : Model<LevelSelectionView>
	{
		[Dropdown(StringCollectionNames.PANELS_COLLECTION_NAME)] 
		[SerializeField] private string mainMenuPanelName;

		public void SelectLevel (int number)
		{
			CurrentView.SetContentState(false);
			SceneLoader.Instance.LoadLevelScene(number);
		}

		public void ShowMainMenu ()
		{
			CurrentView.SetContentState(false);
			UIManager.Instance.ShowPanel(mainMenuPanelName);
		}
	}
}