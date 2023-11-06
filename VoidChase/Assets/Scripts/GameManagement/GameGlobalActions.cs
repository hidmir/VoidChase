using System;

namespace VoidChase.GameManagement
{
	public static class GameGlobalActions
	{
		public static event Action EndGame = delegate { };

		public static void InvokeEndGame ()
		{
			EndGame.Invoke();
		}
	}
}