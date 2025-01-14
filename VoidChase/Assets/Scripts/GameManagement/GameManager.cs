using VoidChase.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.GameManagement
{
	public class GameManager : SingletonMonoBehaviour<GameManager>
	{
		public void EndGame ()
		{
			PauseGame();
			GameGlobalActions.InvokeEndGame();
		}

		public void ExitLevel ()
		{
			GameGlobalActions.InvokeExitLevel();
			SceneLoader.Instance.LoadMainMenuScene();
		}

		public void PauseGame ()
		{
			GameGlobalVariables.IsGamePaused.Value = true;
		}

		public void UnPauseGame ()
		{
			GameGlobalVariables.IsGamePaused.Value = false;
		}

		protected override void Initialize ()
		{
			base.Initialize();
			GameGlobalVariables.IsGamePaused.Value = false;
		}
	}
}