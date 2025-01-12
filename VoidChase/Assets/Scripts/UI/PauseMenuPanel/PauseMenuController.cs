using VoidChase.GameManagement;

namespace VoidChase.UI.PauseMenu
{
	public class PauseMenuController : BasePanelController
	{
		public void UnPauseGame ()
		{
			SetVisibility(false);
			GameManager.Instance.UnPauseGame();
		}

		public void ExitLevel ()
		{
			SetVisibility(false);
			GameManager.Instance.ExitLevel();
		}
	}
}