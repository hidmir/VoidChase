namespace VoidChase.GameLoop.Pause
{
	public interface IPausable
	{
		void OnPause ();
		void OnResume ();

		public void RegisterPausable ()
		{
			PauseManager.Instance.Register(this);
		}

		public void UnregisterPausable ()
		{
			PauseManager pauseManager = PauseManager.Instance;

			if (pauseManager != null)
			{
				pauseManager.Unregister(this);
			}
		}
	}
}