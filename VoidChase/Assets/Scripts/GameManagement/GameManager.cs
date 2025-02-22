using VoidChase.SceneManagement;
using VoidChase.Utilities;

namespace VoidChase.GameManagement
{
	public class GameManager : SingletonMonoBehaviour<GameManager>
	{
		public void EndGame ()
		{
			GameGlobalActions.InvokeEndGame();
		}

		public void ExitLevel ()
		{
			GameGlobalActions.InvokeExitLevel();
			SceneLoader.Instance.LoadMainMenuScene();
		}
	}
}