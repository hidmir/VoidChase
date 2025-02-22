using VoidChase.GameLoop.Pause;
using VoidChase.GameManagement;

namespace VoidChase.UI.PauseMenu
{
	public class PauseMenuController : BasePanelController
	{
		public void UnPauseGame ()
		{
			SetVisibility(false);
			PauseManager.Instance.Resume();
		}

		public void ExitLevel ()
		{
			SetVisibility(false);
			GameManager.Instance.ExitLevel();
			PauseManager.Instance.Resume();
		}
	}
}