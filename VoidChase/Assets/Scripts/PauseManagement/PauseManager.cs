using System.Collections.Generic;
using VoidChase.Utilities;

namespace VoidChase.PauseManagement
{
	public class PauseManager : SingletonMonoBehaviour<PauseManager>
	{
		private readonly List<IPausable> pausableCollection = new ();
		private bool isPaused;

		public void Pause ()
		{
			isPaused = true;

			foreach (IPausable pausable in pausableCollection)
			{
				pausable.OnPause();
			}
		}

		public void Resume ()
		{
			isPaused = false;

			foreach (IPausable pausable in pausableCollection)
			{
				pausable.OnResume();
			}
		}

		public void Register (IPausable pausable)
		{
			pausableCollection.Add(pausable);

			if (isPaused)
			{
				pausable.OnPause();
			}
			else
			{
				pausable.OnResume();
			}
		}

		public void Unregister (IPausable pausable)
		{
			pausableCollection.Remove(pausable);
		}
	}
}