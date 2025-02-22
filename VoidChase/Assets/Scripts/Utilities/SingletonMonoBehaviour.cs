using UnityEngine;

namespace VoidChase.Utilities
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
	{
		public static T Instance { get; private set; }

		protected virtual void Awake ()
		{
			if (Instance == null)
			{
				Instance = (T) this;
				Initialize();
			}
			else
			{
				Destroy(this);
			}
		}

		protected virtual void Initialize () { }

		protected virtual void Shutdown () { }

		private void OnDestroy ()
		{
			if (Instance == this)
			{
				Shutdown();
				Instance = null;
			}
		}
	}
}