using VoidChase.GameManagement;

namespace VoidChase.UI.PauseMenu
{
	public class PauseMenuModel : Model<PauseMenuView>
	{
		public void UnPauseGame ()
		{
			CurrentView.SetContentState(false);
			GameManager.Instance.UnPauseGame();
		}

		public void ExitLevel ()
		{
			CurrentView.SetContentState(false);
			GameManager.Instance.ExitLevel();
		}
	}
}