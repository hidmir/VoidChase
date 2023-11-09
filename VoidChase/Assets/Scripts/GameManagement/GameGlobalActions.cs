using System;

namespace VoidChase.GameManagement
{
	public static class GameGlobalActions
	{
		public static event Action EndGame = delegate { };
		public static event Action ExitLevel = delegate { };

		public static void InvokeEndGame ()
		{
			EndGame.Invoke();
		}

		public static void InvokeExitLevel ()
		{
			ExitLevel.Invoke();
		}
	}
}