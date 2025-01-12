using UnityEngine;

namespace VoidChase.Utilities
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		protected virtual void Awake ()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}