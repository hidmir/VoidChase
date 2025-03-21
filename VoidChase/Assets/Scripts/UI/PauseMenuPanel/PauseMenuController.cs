using VoidChase.GameLoop;
using VoidChase.GameLoop.Pause;

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
			GameLoopManager.Instance.ExitLevel();
		}
	}
}