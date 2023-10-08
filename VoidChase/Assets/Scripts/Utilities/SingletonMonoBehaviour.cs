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
			}
			else
			{
				Destroy(this);
			}

			Initialize();
		}

		protected virtual void Initialize () { }

		private void OnDestroy ()
		{
			Instance = null;
		}
	}
}